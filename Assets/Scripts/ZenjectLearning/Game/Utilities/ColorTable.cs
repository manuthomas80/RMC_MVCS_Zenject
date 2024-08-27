using UnityEngine;

namespace ZenjectLearning.Game.Utilities
{
    public static class ColorTable
    {
        // 50 predefined color constants
        public static Color Red = new Color( 1f, 0f, 0f );      // Red
        public static Color Green = new Color( 0f, 1f, 0f );    // Green
        public static Color Blue = new Color( 0f, 0f, 1f );     // Blue
        public static Color Yellow = new Color( 1f, 1f, 0f );   // Yellow
        public static Color Magenta = new Color( 1f, 0f, 1f );  // Magenta
        public static Color Cyan = new Color( 0f, 1f, 1f );     // Cyan
        public static Color Black = new Color( 0f, 0f, 0f );    // Black
        public static Color White = new Color( 1f, 1f, 1f );    // White
        public static Color Gray = new Color( 0.5f, 0.5f, 0.5f );  // Gray
        public static Color Orange = new Color( 1f, 0.5f, 0f );     // Orange
        public static Color Purple = new Color( 0.5f, 0f, 0.5f );   // Purple
        public static Color Olive = new Color( 0.5f, 0.5f, 0f );    // Olive
        public static Color Brown = new Color( 0.6f, 0.4f, 0.2f );  // Brown
        public static Color LightGray = new Color( 0.75f, 0.75f, 0.75f );  // Light Gray
        public static Color Teal = new Color( 0f, 0.5f, 0.5f );      // Teal
        public static Color Peach = new Color( 1f, 0.8f, 0.6f );     // Peach
        public static Color Copper = new Color( 1f, 0.6f, 0.2f );    // Copper
        public static Color Pink = new Color( 1f, 0.9f, 0.8f );      // Pink
        public static Color Coffee = new Color( 0.6f, 0.4f, 0.2f );  // Coffee
        public static Color Gold = new Color( 0.9f, 0.7f, 0.1f );    // Gold
        public static Color Plum = new Color( 0.7f, 0.3f, 0.7f );    // Plum
        public static Color MossGreen = new Color( 0.3f, 0.6f, 0.3f );  // Moss Green
        public static Color LimeGreen = new Color( 0.3f, 0.8f, 0.4f );  // Lime Green
        public static Color SapphireBlue = new Color( 0.2f, 0.4f, 0.9f );  // Sapphire Blue
        public static Color DeepPink = new Color( 0.8f, 0.2f, 0.6f );  // Deep Pink
        public static Color SkyBlue = new Color( 0.2f, 0.5f, 0.7f );  // Sky Blue
        public static Color Lemon = new Color( 0.9f, 0.9f, 0.1f );    // Lemon
        public static Color RoyalBlue = new Color( 0.1f, 0.2f, 0.8f );  // Royal Blue
        public static Color TomatoRed = new Color( 0.9f, 0.3f, 0.3f );  // Tomato Red
        public static Color FireBrick = new Color( 0.8f, 0.1f, 0.1f );  // Fire Brick
        public static Color Rust = new Color( 0.7f, 0.2f, 0.1f );     // Rust
        public static Color Mustard = new Color( 0.8f, 0.6f, 0.1f );  // Mustard
        public static Color GrassGreen = new Color( 0.4f, 0.7f, 0.2f );  // Grass Green
        public static Color Aqua = new Color( 0.1f, 0.7f, 0.9f );     // Aqua
        public static Color Lavender = new Color( 0.7f, 0.4f, 0.8f );  // Lavender
        public static Color LightCoral = new Color( 0.9f, 0.7f, 0.7f );  // Light Coral
        public static Color Chartreuse = new Color( 0.6f, 0.8f, 0.2f );  // Chartreuse
        public static Color Orchid = new Color( 0.9f, 0.6f, 0.8f );   // Orchid
        public static Color PaleTurquoise = new Color( 0.7f, 0.9f, 0.9f );  // Pale Turquoise
        public static Color Salmon = new Color( 0.9f, 0.5f, 0.5f );   // Salmon
        public static Color HotPink = new Color( 0.9f, 0.4f, 0.7f );  // Hot Pink
        public static Color MintGreen = new Color( 0.3f, 0.9f, 0.3f );  // Mint Green
        public static Color Violet = new Color( 0.8f, 0.3f, 0.8f );   // Violet
        public static Color Indigo = new Color( 0.6f, 0.2f, 0.9f );   // Indigo
        public static Color Wheat = new Color( 0.9f, 0.8f, 0.5f );    // Wheat
        public static Color ForestGreen = new Color( 0.2f, 0.5f, 0.3f );  // Forest Green
        public static Color Crimson = new Color( 0.9f, 0.4f, 0.4f );  // Crimson
        public static Color Snow = new Color( 0.9f, 0.9f, 0.9f );     // Snow
        public static Color SlateBlue = new Color( 0.5f, 0.5f, 0.8f );  // Slate Blue

        // Function to return a random color from the defined colors
        public static Color GetRandomColor( )
        {
            // List of all colors in the class
            Color[ ] allColors = 
            {
                Red, Green, Blue, Yellow, Magenta, Cyan, Black, White, Gray, Orange, 
                Purple, Olive, Brown, LightGray, Teal, Peach, Copper, Pink, Coffee, Gold,
                Plum, MossGreen, LimeGreen, SapphireBlue, DeepPink, SkyBlue, Lemon, RoyalBlue, TomatoRed, 
                FireBrick, Rust, Mustard, GrassGreen, Aqua, Lavender, LightCoral, Chartreuse, Orchid, 
                PaleTurquoise, Salmon, HotPink, MintGreen, Violet, Indigo, Wheat, ForestGreen, Crimson, Snow, SlateBlue
            };
            
            // Pick a random index
            var randomIndex = Random.Range( 0, allColors.Length );
            
            // Return the color at that index
            return allColors[ randomIndex ];
        }
    }
}
