using MySql.Data.MySqlClient;
using System.Data;

namespace DAT602_Game_XanderC
{
    public class Tile
    {
        // Properties
        public int id { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public int sword { get; set; }
        public int armor { get; set; }
        public int potion { get; set; }
        public int shield { get; set; }
        public bool IsLegal { get; set; }

        // Form objects
        public GameboardForm? tile_form;
        public PictureBox? TileDisplay;
        public PictureBox? SwordDisplay;
        public PictureBox? ArmorDisplay;
        public PictureBox? PotionDisplay;
        public PictureBox? ShieldDisplay;

        // List of tiles
        public static List<Tile> lcTiles = new List<Tile>();

        // Check if the tile is a legal move
        public bool IsLegalMove(Tile currentTile)
        {
            int rowDiff = Math.Abs(this.row - currentTile.row);
            int colDiff = Math.Abs(this.col - currentTile.col);
            return (rowDiff <= 1 && colDiff <= 1) && !(rowDiff == 0 && colDiff == 0);
        }

        // Check if the tile is adjacent
        public bool IsAdjacent(Tile otherTile)
        {
            // Check if the other tile is adjacent (horizontally or vertically)
            return (Math.Abs(this.row - otherTile.row) <= 1 && Math.Abs(this.col - otherTile.col) <= 1);
        }

        // Move the player to the tile
        private bool MovePlayerInDatabase(int playerId, int tileId)
        {
            // Set the success flag to false
            bool success = false;

            // Connect to the database
            using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=DAT602TILES;Uid=root;password=@useVim97;"))
            {
                connection.Open();
                using (var command = new MySqlCommand("MovePlayer", connection))
                {
                    // Call the stored procedure to move the player
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_player_id", playerId);
                    command.Parameters.AddWithValue("p_tile_id", tileId);
                    var successParam = new MySqlParameter("p_success", MySqlDbType.Bit);
                    successParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(successParam);

                    command.ExecuteNonQuery();
                    success = (bool)successParam.Value;
                }
            }

            return success;
        }

        // Click event for the PictureBox
        public void EgPictureBox_Click(object sender, EventArgs e)
        {
            // Get the PictureBox that was clicked
            PictureBox theOneClicked = (PictureBox)sender;
            Tile clickedTile = lcTiles.FirstOrDefault(t => t.TileDisplay == theOneClicked);

            // Check if the player is moving to a new tile
            if (clickedTile != null && tile_form != null && Player.CurrentPlayer.TileID > 0 && Player.CurrentPlayer.TileID <= lcTiles.Count && clickedTile.IsLegalMove(lcTiles[Player.CurrentPlayer.TileID - 1]))
            {
                // Call the stored procedure to move the player
                bool success = MovePlayerInDatabase(Player.CurrentPlayer.TileID, clickedTile.id);

                if (success)
                {
                    // Get the current tile
                    Tile currentTile = lcTiles[Player.CurrentPlayer.TileID - 1];

                    // Change the background color of the current tile to indicate the player has moved
                    currentTile.TileDisplay.BackColor = Color.White;

                    // Update the player's current tile ID to the new tile ID
                    Player.CurrentPlayer.Update = true;
                    Player.CurrentPlayer.TileID = clickedTile.id;
                    Player.CurrentPlayer.Update = false;

                    // Change the background color of the new tile to indicate the player's new position
                    clickedTile.TileDisplay.BackColor = Color.Green;

                    // Ensure items remain in their positions
                    UpdateItemDisplays(currentTile);
                    UpdateItemDisplays(clickedTile);
                }
                else
                {
                    MessageBox.Show("Move not allowed. The tile is either occupied or does not exist.");
                }
            }
        }

        // Update the item displays
        private void UpdateItemDisplays(Tile tile)
        {
            if (tile.SwordDisplay != null)
                tile.SwordDisplay.Visible = tile.sword > 0;
            if (tile.ArmorDisplay != null)
                tile.ArmorDisplay.Visible = tile.armor > 0;
            if (tile.PotionDisplay != null)
                tile.PotionDisplay.Visible = tile.potion > 0;
            if (tile.ShieldDisplay != null)
                tile.ShieldDisplay.Visible = tile.shield > 0;
        }
    }
}