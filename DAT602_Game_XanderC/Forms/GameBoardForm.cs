using DAT602_Game_XanderC.Objects;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace DAT602_Game_XanderC
{
    public partial class GameboardForm : Form
    {
        private MainScreenForm _home;
        private bool _itemsPlaced = false;
        private Dictionary<int, Item> _itemLocations = new Dictionary<int, Item>();
        // Game Timer
        private int _remainingTime = 30;
        private System.Windows.Forms.Timer gameTimer;

        public GameboardForm(MainScreenForm home)
        {
            _home = home;
            InitializeComponent();
            InitializeGameboard();
            InitializeGameTimer();
            StartGameTimer();
        }

        // Initialize the game timer
        private void InitializeGameTimer()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // Set the interval to 1 second or any desired value
            gameTimer.Tick += GameTimer_Tick; // Attach an event handler for the Tick event
        }

        // Start the game timer
        private void StartGameTimer()
        {
            _remainingTime = 30; // Reset the timer
            gameTimer.Start();
        }

        // Event handler for the game timer tick
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _remainingTime--;
            timeLabel.Text = $"Time: {_remainingTime}"; // Update the time label
            if (_remainingTime <= 0)
            {
                gameTimer.Stop();
                EndGame();
            }
        }

        // End the game
        private void EndGame()
        {
            MessageBox.Show($"Time's up! Your score is {_home._player.Score}.");
            DisableGameboard();
        }

        // Disable the gameboard controls
        private void DisableGameboard()
        {
            foreach (Control control in boardPanel.Controls)
            {
                control.Enabled = false;
            }
        }

        // Initialize the gameboard
        private void InitializeGameboard()
        {
            if (_home._player != null)
            {
                // Place the player on a legal tile
                PlacePlayerOnLegalTile();
            }
            InitializeBoard();
        }

        // Event handler for tile click
        private void Tile_Click(object sender, EventArgs e, Tile tile)
        {
            MovePlayerToTile(tile);
        }

        // Place the player on a legal tile
        public void PlacePlayerOnLegalTile()
        {
            clsPlayerDAO dbAccess = new clsPlayerDAO();
            var legalTiles = dbAccess.GetAllTiles(this).Where(tile => tile.IsLegal).ToList();

            // Filter out tiles that have items on them
            var tilesWithoutItems = legalTiles.Where(tile =>
                tile.sword == 0 &&
                tile.armor == 0 &&
                tile.potion == 0 &&
                tile.shield == 0).ToList();

            // Check if there are any tiles without items
            if (tilesWithoutItems.Any())
            {
                var random = new Random();
                var randomTile = tilesWithoutItems[random.Next(tilesWithoutItems.Count)];
                _home._player.TileID = randomTile.id;
                _home._player.CurrentTile = randomTile; // Set the current tile

                // Update the player's current tile in the database
                dbAccess.UpdatePlayerTile(Convert.ToInt32(_home._player.PlayerID), _home._player.TileID);
            }
            else
            {
                MessageBox.Show("No legal tiles available without items.");
            }
        }

        // Move the player to a specified tile
        private void MovePlayerToTile(Tile tile)
        {
            // Check if the player is initialized and the tile is a legal move
            if (_home._player != null && tile.IsLegalMove(_home._player.CurrentTile))
            {
                if (_home._player.CurrentTile != null && !_home._player.CurrentTile.IsAdjacent(tile))
                {
                    MessageBox.Show("You can only move to an adjacent tile.");
                    return;
                }

                // Create an instance of the player data access object
                clsPlayerDAO dbAccess = new clsPlayerDAO();
                int currentTileId = _home._player.TileID;

                // Check if the tile is occupied by another player
                if (Player.lcPlayers.Any(p => p.TileID == tile.id && p != _home._player))
                {
                    MessageBox.Show("The tile is occupied by another player.");
                    return;
                }

                // Move the player to the new tile
                bool success = dbAccess.MovePlayer(Convert.ToInt32(_home._player.PlayerID), tile.id);
                if (success)
                {
                    // Remove the player from the current tile
                    if (_home._player.CurrentTile != null)
                    {
                        _home._player.CurrentTile.TileDisplay.BackColor = Color.DarkGray;
                    }

                    // Update the player's TileID and CurrentTile
                    _home._player.TileID = tile.id;
                    _home._player.CurrentTile = tile;

                    // Update the player's position on the board
                    UpdatePlayerPosition();

                    // Check if the tile has an item and collect it
                    var itemOnTile = _itemLocations.Values.FirstOrDefault(item => item.TileID == tile.id);
                    if (itemOnTile != null)
                    {
                        CollectItem(itemOnTile);
                        Debug.WriteLine($"Item found on tile: {itemOnTile.Description} (ID: {itemOnTile.ItemID})");
                    }
                    else
                    {
                        Debug.WriteLine("No item found on the tile.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to move player. The tile might be occupied or invalid.");
                }
            }
        }

        // Collect an item from a tile
        private void CollectItem(Item item)
        {
            Debug.WriteLine($"Attempting to collect item: {item.Description} (ID: {item.ItemID})");

            // Remove the item from the board
            var tile = Tile.lcTiles.FirstOrDefault(t => t.id == item.TileID);
            if (tile != null)
            {
                switch (item.Description.ToLower())
                {
                    case "sword":
                        tile.sword = 0;
                        tile.SwordDisplay.Visible = false;
                        break;
                    case "armor":
                        tile.armor = 0;
                        tile.ArmorDisplay.Visible = false;
                        break;
                    case "potion":
                        tile.potion = 0;
                        tile.PotionDisplay.Visible = false;
                        break;
                    case "shield":
                        tile.shield = 0;
                        tile.ShieldDisplay.Visible = false;
                        break;
                }
            }

            // Remove the item from the dictionary
            _itemLocations.Remove(item.ItemID);

            // Update the player's score
            _home._player.Score += item.Points;
            Console.WriteLine($"Player's new score: {_home._player.Score}");

            // Respawn the item in a new random location
            RespawnItem(item);

            // Update the player's position on the board
            UpdatePlayerPosition();
        }

        // Initialize the gameboard tiles and items
        private void InitializeBoard()
        {
            clsPlayerDAO dbAccess = new clsPlayerDAO();

            Tile.lcTiles = dbAccess.GetAllTiles(this);

            // Clear existing controls
            boardPanel.Controls.Clear();

            // Initialize the gameboard tiles
            var lcTiles = Tile.lcTiles;
            var lcPlayers = Player.lcPlayers;
            PictureBox currentTilePic;
            foreach (var tile in lcTiles)
            {
                // Create a PictureBox control for the tile
                currentTilePic = new PictureBox();
                currentTilePic.Click += (sender, e) => Tile_Click(sender, e, tile);
                boardPanel.Controls.Add(currentTilePic);
                tile.TileDisplay = currentTilePic;
                currentTilePic.Width = (boardPanel.Width / 10) - 1;
                currentTilePic.Height = (boardPanel.Height / 10) - 1;
                currentTilePic.BackColor = Color.DarkGray;
                currentTilePic.Location = new Point(tile.col * (currentTilePic.Width + 1), tile.row * (currentTilePic.Height + 1));

                // Initialize item PictureBox controls
                tile.SwordDisplay = new PictureBox();
                tile.ArmorDisplay = new PictureBox();
                tile.PotionDisplay = new PictureBox();
                tile.ShieldDisplay = new PictureBox();

                // Add item PictureBox controls to the TileDisplay
                currentTilePic.Controls.Add(tile.SwordDisplay);
                currentTilePic.Controls.Add(tile.ArmorDisplay);
                currentTilePic.Controls.Add(tile.PotionDisplay);
                currentTilePic.Controls.Add(tile.ShieldDisplay);

                // Set initial visibility to false
                tile.SwordDisplay.Visible = false;
                tile.ArmorDisplay.Visible = false;
                tile.PotionDisplay.Visible = false;
                tile.ShieldDisplay.Visible = false;
            }

            // Place items on the gameboard if not already placed
            if (!_itemsPlaced)
            {
                var items = dbAccess.GetAllItems();
                PlaceItemsOnGameboard(items);
                _itemsPlaced = true; // Set the flag to true after placing items
            }

            UpdatePlayerPosition();
        }

        // Place items on the gameboard
        private void PlaceItemsOnGameboard(List<Item> items)
        {
            Random random = new Random();
            HashSet<int> usedTileIds = new HashSet<int>();

            // Place each item on a random tile
            foreach (var item in items)
            {
                Tile tile;
                do
                {
                    int randomTileIndex = random.Next(Tile.lcTiles.Count);
                    tile = Tile.lcTiles[randomTileIndex];
                } while (usedTileIds.Contains(tile.id));

                usedTileIds.Add(tile.id);
                item.TileID = tile.id;

                // Update the item location dictionary
                _itemLocations[item.ItemID] = item;

                // Calculate the center position for the item
                int centerX = (tile.TileDisplay.Width - 20) / 2;
                int centerY = (tile.TileDisplay.Height - 20) / 2;

                // Set the item PictureBox visibility, position, and enable state based on the item type
                switch (item.Description.ToLower())
                {
                    case "sword":
                        tile.sword = 1;
                        tile.SwordDisplay.Visible = true;
                        tile.SwordDisplay.BackColor = Color.Green; // Example color
                        tile.SwordDisplay.Size = new Size(20, 20); // Example size
                        tile.SwordDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                        tile.SwordDisplay.Enabled = false; // Allow click-through
                        break;
                    case "armor":
                        tile.armor = 1;
                        tile.ArmorDisplay.Visible = true;
                        tile.ArmorDisplay.BackColor = Color.Red; // Example color
                        tile.ArmorDisplay.Size = new Size(20, 20); // Example size
                        tile.ArmorDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                        tile.ArmorDisplay.Enabled = false; // Allow click-through
                        break;
                    case "potion":
                        tile.potion = 1;
                        tile.PotionDisplay.Visible = true;
                        tile.PotionDisplay.BackColor = Color.Blue; // Example color
                        tile.PotionDisplay.Size = new Size(20, 20); // Example size
                        tile.PotionDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                        tile.PotionDisplay.Enabled = false; // Allow click-through
                        break;
                    case "shield":
                        tile.shield = 1;
                        tile.ShieldDisplay.Visible = true;
                        tile.ShieldDisplay.BackColor = Color.Yellow; // Example color
                        tile.ShieldDisplay.Size = new Size(20, 20); // Example size
                        tile.ShieldDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                        tile.ShieldDisplay.Enabled = false; // Allow click-through
                        break;
                }

                Debug.WriteLine($"Item {item.Description} (ID: {item.ItemID}) placed on tile {tile.id}");
            }
        }

        // Respawn an item in a new random location
        private void RespawnItem(Item item)
        {
            Random random = new Random();
            Tile tile;
            do
            {
                int randomTileIndex = random.Next(Tile.lcTiles.Count);
                tile = Tile.lcTiles[randomTileIndex];
            } while (tile.id == item.TileID); // Ensure the item is not placed on the same tile

            item.TileID = tile.id;

            // Update the item location dictionary
            _itemLocations[item.ItemID] = item;

            // Calculate the center position for the item
            int centerX = (tile.TileDisplay.Width - 20) / 2;
            int centerY = (tile.TileDisplay.Height - 20) / 2;

            // Set the item PictureBox visibility, position, and enable state based on the item type
            switch (item.Description.ToLower())
            {
                case "sword":
                    tile.sword = 1;
                    tile.SwordDisplay.Visible = true;
                    tile.SwordDisplay.BackColor = Color.Green; // Example color
                    tile.SwordDisplay.Size = new Size(20, 20); // Example size
                    tile.SwordDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                    tile.SwordDisplay.Enabled = false; // Allow click-through
                    break;
                case "armor":
                    tile.armor = 1;
                    tile.ArmorDisplay.Visible = true;
                    tile.ArmorDisplay.BackColor = Color.Red; // Example color
                    tile.ArmorDisplay.Size = new Size(20, 20); // Example size
                    tile.ArmorDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                    tile.ArmorDisplay.Enabled = false; // Allow click-through
                    break;
                case "potion":
                    tile.potion = 1;
                    tile.PotionDisplay.Visible = true;
                    tile.PotionDisplay.BackColor = Color.Blue; // Example color
                    tile.PotionDisplay.Size = new Size(20, 20); // Example size
                    tile.PotionDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                    tile.PotionDisplay.Enabled = false; // Allow click-through
                    break;
                case "shield":
                    tile.shield = 1;
                    tile.ShieldDisplay.Visible = true;
                    tile.ShieldDisplay.BackColor = Color.Yellow; // Example color
                    tile.ShieldDisplay.Size = new Size(20, 20); // Example size
                    tile.ShieldDisplay.Location = new Point(centerX, centerY); // Center position within the tile
                    tile.ShieldDisplay.Enabled = false; // Allow click-through
                    break;
            }

            Debug.WriteLine($"Item {item.Description} (ID: {item.ItemID}) respawned on tile {tile.id}");
        }

        // Update the player's position on the gameboard
        private void UpdatePlayerPosition()
        {
            if (_home._player != null)
            {
                var playerTile = Tile.lcTiles.FirstOrDefault(t => t.id == _home._player.TileID);
                if (playerTile != null)
                {
                    // Highlight the current player's tile
                    playerTile.TileDisplay.BackColor = Color.Black;

                    // Update the scoreboards
                    YourScoreboard.Text = "Your Score = " + _home._player.Score.ToString();

                    // Calculate opponents' scores
                    int opponentsScore = Player.lcPlayers.Where(p => p != _home._player).Sum(p => p.Score);

                    Debug.WriteLine($"Player position updated to tile {playerTile.id}");
                }
                else
                {
                    Debug.WriteLine("Player tile not found.");
                }
            }
        }

        // Event handler for the back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            if (_home._player != null)
            {
                _home._player.Score = 0;
            }
            this.Hide();
            _home.Show();
            this.Dispose();
        }

        // Event handler for the new game button click
        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            if (_home._player != null)
            {
                _home._player.Score = 0;
            }
            GameboardForm newGameboard = new GameboardForm(_home);
            newGameboard.Show();
            this.Close();
        }

        // Event handler for the stop game button click
        private void StopGameBtn_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
            MessageBox.Show($"Game stopped! Your score is {_home._player.Score}.");
            DisableGameboard();
        }
    }
}