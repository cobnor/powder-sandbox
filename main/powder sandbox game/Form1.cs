using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace powder_sandbox_game
{
    public partial class Form1 : Form
    {
        //   globals   //
        Bitmap displayBmp;
        World world;
        Random r = new Random();
        string selectedElement = "sand";
        //constants
        int cellSize = 3;
        int worldXOffset;
        int worldYOffset;
        MouseEventArgs mouseInfo;
        bool mouseDown = false;
        string brushMode = "circle";

        int dustHue;

        bool paused = false;

        string currentTheme = "light";
        //   objects and structures  //
        public struct World
        {
            // constructor for world struct
            // set sizeX and sizeY to indicate vertical and horizontal world size
            public World(int SizeX, int SizeY)
            {
                sizeX = SizeX;
                sizeY = SizeY;
                // 2D array of cells
                worldArray = new Element[SizeX, SizeY];
            }
            // initialise empty world with empty cells
            public void generateWorld()
            {
                for (int row = 0; row < sizeY; row++)
                {
                    for (int col = 0; col < sizeX; col++)
                    {
                        worldArray[col, row] = new Element("Air", "Empty", Color.White, Flammability: 2);
                    }
                }
            }
            //debug routine to display board
            public void displayDebug()
            {
                for (int row = 0; row < sizeY; row++)
                {
                    for (int col = 0; col < sizeX; col++)
                    {
                        if (worldArray[col, row].name == "Air")
                        {
                            Console.Write(" ,");
                        }
                        else if (worldArray[col, row].name == "Water")
                        {
                            Console.Write("W,");
                        }
                    }
                    Console.WriteLine();
                }
            }
            //setter and getter functions
            //size X and Y only need get since they will only be written at the start
            public int sizeX { get; }
            public int sizeY { get; }
            public Element[,] worldArray { get; set; }
        }

        public class Element
        {
            public Element(string Name, string State, Color Colour, int dispersionRate = 1, double Bounciness = 0, int Flammability = 0, int ExplosionResistance = 0, bool DoesRise = false, bool CanSmoke = true)
            {
                name = Name;
                //state can be solid, water, gas, immovable or fire
                state = State;
                colour = Colour;
                //flags
                isProcessed = false;
                isProjectile = false;

                canSmoke = CanSmoke;
                //represents how far liquid can move horizontally in one frame
                liquidDispersionRate = dispersionRate;
                //x and y velocity
                xVelocity = 0;
                yVelocity = 0;
                //double between 0 and 1 indicating how much velocity is conserved after a collision
                bounciness = Bounciness;
                //number between 1 and 100 indicating how flammable a material is
                flammability = Flammability;

                explosionResistance = ExplosionResistance;
                doesRise = DoesRise;
            }
            //setter and getter functions
            public string name { get; }
            public string state { get; }
            public Color colour { get; set; }
            public bool isProcessed { get; set; }
            public bool isProjectile { get; set; }
            public bool canSmoke { get; set; }
            public bool doesRise { get; }
            public double xVelocity { get; set; }
            public double yVelocity { get; set; }
            public int liquidDispersionRate { get; set; }
            public double bounciness { get; set; }
            public int flammability { get; }
            public int explosionResistance { get; }
        }


        public Form1()
        {
            InitializeComponent();
        }
        //   functions   //
        private void Form1_Load(object sender, EventArgs e)
        {
            //set cmbTheme default value
            cmbTheme.SelectedIndex = 1;
            //set up world and scale it to size of picture box
            int worldWidth = pctDisplay.Width / cellSize;
            int worldHeight = pctDisplay.Height / cellSize;

            worldXOffset = (pctDisplay.Width % cellSize) / 2;
            worldYOffset = (pctDisplay.Height % cellSize) / 2;

            world = new World(worldWidth, worldHeight);
            world.generateWorld();

            dustHue = r.Next(0, 360);
        }

        //use bresenham line algorithm to get path between two points

        private List<Point> getPath(int startX, int startY, int endX, int endY)
        {
            //blank list of points
            List<Point> path = new List<Point>();

            if (endX == startX && endY == startY)
            {
                return path;
            }

            double gradient = Convert.ToDouble(endY - startY) / Convert.ToDouble(endX - startX);

            // if horizontal
            if (Math.Abs(endY - startY) <= Math.Abs(endX - startX))
            {
                // if right octant
                if (startX < endX)
                {
                    int y;
                    for (int x = startX; x <= endX; x++)
                    {
                        y = Convert.ToInt32(Math.Round(gradient * (x - startX))) + startY;
                        path.Add(new Point(x, y));
                    }
                }

                // if left octant
                else
                {
                    int y;
                    for (int x = startX; x >= endX; x--)
                    {
                        y = Convert.ToInt32(Math.Round(gradient * (x - startX))) + startY;
                        path.Add(new Point(x, y));
                    }
                }

            }
            //if vertical
            else
            {
                // if upper octant
                if (startY < endY)
                {
                    int x;
                    for (int y = startY; y <= endY; y++)
                    {
                        x = Convert.ToInt32(Math.Round((y - startY) / gradient)) + startX;
                        path.Add(new Point(x, y));
                    }
                }

                // if lower octant
                else
                {
                    int x;
                    for (int y = startY; y >= endY; y--)
                    {
                        x = Convert.ToInt32(Math.Round((y - startY) / gradient)) + startX;
                        path.Add(new Point(x, y));
                    }
                }
            }
            path.RemoveAt(0);

            return path;
        }


        //swap two elements in the world array given their positions
        private void swapElems(int x1, int y1, int x2, int y2)
        {
            Element temp = world.worldArray[x2, y2];
            world.worldArray[x2, y2] = world.worldArray[x1, y1];
            world.worldArray[x1, y1] = temp;
        }

        private void drawWorld()
        {

            //refresh bitmap
            displayBmp = new Bitmap(pctDisplay.Width, pctDisplay.Height);
            //generate graphics object from bitmap
            Graphics g = Graphics.FromImage(displayBmp);


            //materials
            SolidBrush emptyBrush = new SolidBrush(Color.FromArgb(230, 230, 230));
            SolidBrush nightBrush = new SolidBrush(Color.FromArgb(12, 24, 33));

            SolidBrush currentBrush = new SolidBrush(Color.White);

            //clear screen before drawing next frame
            switch (currentTheme)
            {
                case "light":
                    g.FillRectangle(emptyBrush, 0, 0, pctDisplay.Width, pctDisplay.Height);
                    break;

                case "dark":
                    g.FillRectangle(nightBrush, 0, 0, pctDisplay.Width, pctDisplay.Height);
                    break;
                case "colourful":
                    g.FillRectangle(nightBrush, 0, 0, pctDisplay.Width, pctDisplay.Height);
                    break;
            }

            for (int row = 0; row < world.sizeY; row++)
            {
                for (int col = 0; col < world.sizeX; col++)
                {
                    Element currentElement = world.worldArray[col, row];

                    // if drawing empty cell
                    if (currentElement.state == "Empty")
                    {
                        // continue to next cell to save time
                        continue;
                    }

                    currentBrush.Color = currentElement.colour;

                    //add offset to x and y to compensate for cell size not exactly dividing pctDisplay dimensions
                    //subtract number from cellSize to add lines between cells

                    g.FillRectangle(currentBrush, col * cellSize + worldXOffset, row * cellSize + worldYOffset, cellSize, cellSize);
                }
            }

            //dispose of brushes to avoid excess memory use
            g.Dispose();
            emptyBrush.Dispose();
            nightBrush.Dispose();

        }



        private void updateWorld()
        {
            //randomise process order
            //for both the x and y
            IEnumerable<int> processOrderX = Enumerable.Range(0, world.sizeX).OrderBy(a => r.Next());
            IEnumerable<int> processOrderY = Enumerable.Range(0, world.sizeY).OrderBy(a => r.Next());

            //loop through random process order in y
            foreach (int row in processOrderY)
            {
                //loop through random process order in x
                foreach (int col in processOrderX)
                {
                    //set elements with air below them to projectile state
                    //this should not happen with all elements
                    //so air, fire and gas cannot be projectiles
                    if (world.worldArray[col, row].state != "Empty" && row != world.sizeY - 1
                        && world.worldArray[col, row + 1].state == "Empty" 
                         && world.worldArray[col, row].state != "Fire"
                         && world.worldArray[col, row].state != "Gas")
                    {
                        if (world.worldArray[col, row].state == "Empty")
                        {
                            continue;
                        }
                        world.worldArray[col, row].isProjectile = true;
                    }

                    Element currentElement = world.worldArray[col, row];

                    //calculate physics for projectilesS
                    if (currentElement.isProjectile)
                    {
                        updateProjectile(col, row, currentElement);
                    }
                    else
                    {
                        //call update routine on element based on on state
                        switch (currentElement.state)
                        {
                            case "Solid":
                                updateSolid(col, row, currentElement);
                                break;
                            case "Liquid":
                                updateLiquid(col, row, currentElement);
                                break;
                            case "Fire":
                                updateFire(col, row, currentElement);
                                break;
                            case "Immovable":
                                world.worldArray[col, row].isProcessed = true;
                                break;
                            case "Gas":
                                updateGas(col, row, currentElement);
                                break;

                        }
                    }

                }
            }
            //reset the isProcessed flag
            for (int row = 0; row < world.sizeY; row++)
            {
                for (int col = 0; col < world.sizeX; col++)
                {
                    world.worldArray[col, row].isProcessed = false;
                }
            }

            

        }

        private void updateProjectile(int x, int y, Element elem)
        {
            //immovables cannot be projectiles
            if (elem.isProcessed)
            {
                return;
            }
            
            //set elem.isProcessed so it does not get processed multiple times per frame
            elem.isProcessed = true;

            if (elem.state == "Immovable" || elem.state == "Empty")
            {
                elem.isProjectile = false;
                return;
            }


            // target coordinates calculated based on x and y velocity
            int targetX = x + Convert.ToInt32(elem.xVelocity);
            int targetY = y + Convert.ToInt32(elem.yVelocity);

            List<Point> directPath = getPath(x, y, targetX, targetY);

            Point endPos = new Point(x, y);
            Point currentPos = new Point(x, y);

            bool down;
            bool right;
            bool left;
            //loop through the calculated direct path from bresenham algorithm and stop it if path is obstructed
            foreach (Point p in directPath)
            {
                // if doesnt encounter a border or an occupied cell, set this as the new end position
                if (p.X >= 0 && p.X < world.sizeX &&
                    p.Y >= 0 && p.Y < world.sizeY &&
                    (world.worldArray[p.X, p.Y].state == "Empty" || world.worldArray[p.X, p.Y].state == "Gas"))
                {
                    endPos = p;
                }
                // if it does encounter a border or occupied cell, decide what to do
                else
                {
                    down = endPos.Y + 1 >= world.sizeY || world.worldArray[endPos.X, endPos.Y + 1].state == "Solid";
                    right = endPos.X + 1 >= world.sizeX || world.worldArray[endPos.X + 1, endPos.Y].state == "Solid";
                    left = endPos.X - 1 < 0 || world.worldArray[endPos.X - 1, endPos.Y].state == "Solid";

                    //bouncy elements should bounce instead of settle when they hit an object
                    if (Math.Abs(elem.xVelocity) > 1 && (right | left))
                    {
                        elem.xVelocity = -elem.xVelocity * elem.bounciness;
                    }
                    //make elements bounce
                    else if (Math.Abs(elem.yVelocity) > 1 && down && elem.bounciness > 0)
                    {
                        //vertical bounce
                        elem.yVelocity = -elem.yVelocity * elem.bounciness;

                        //horizontal bounce
                        if (right)
                        {
                            elem.xVelocity = 2 * elem.bounciness;
                        }
                        else if (left)
                        {
                            elem.xVelocity = -2 * elem.bounciness;
                        }
                    }
                    else
                    {
                        //if  it touches an object then it should no longer act as a projectile
                        if(p.X <= 0 || p.X >= world.sizeX-1 ||
                            p.Y <= 0 || p.Y >= world.sizeY-1 || 
                            !world.worldArray[p.X, p.Y].isProjectile)
                        {
                            elem.isProjectile = false;
                            elem.xVelocity = 0;
                            elem.yVelocity = 0;
                        }
                        
                    }

                    break;
                }
            }
            // if a projectile is really slow in both directions then stop treating it as a projectile
            if (Math.Abs(elem.yVelocity) < 0.1 && Math.Abs(elem.xVelocity) < 0.1
                && !(endPos.Y + 1 < world.sizeY && world.worldArray[endPos.X, endPos.Y + 1].state == "Empty"))
            {
                elem.isProjectile = false;
            }
            if (elem.isProjectile)
            {
                // some elements should rise
                if (elem.doesRise)
                {
                    elem.yVelocity -= 0.2;

                    if (elem.xVelocity > 0)
                    {
                        elem.xVelocity -= 0.2;
                    }
                    else
                    {
                        elem.xVelocity += 0.2;
                    }
                }
                else
                { // some elements should fall
                    elem.yVelocity += 0.2;
                }
            }

            if (elem.state == "Fire" && r.Next(1,5) == 1){
                elem.isProjectile = false;
                elem.xVelocity = 0;
                elem.yVelocity = 0;
            }
            swapElems(x, y, endPos.X, endPos.Y);

        }
        private void updateSolid(int x, int y, Element elem)
        {
            //if at bottom of screen
            if (elem.isProcessed || y + 1 == world.sizeY)
            {
                return;
            }
            elem.isProcessed = true;
            bool down = world.worldArray[x, y + 1].state != "Solid" && world.worldArray[x, y + 1].state != "Immovable";
            bool dright = x + 1 != world.sizeX && world.worldArray[x + 1, y + 1].state != "Solid" && world.worldArray[x + 1, y + 1].state != "Immovable";
            bool dleft = x - 1 != -1 && world.worldArray[x - 1, y + 1].state != "Solid" && world.worldArray[x - 1, y + 1].state != "Immovable";
            //fall if can
            if (down)
            {
                //swap current particle and the one below it
                swapElems(x, y, x, y + 1);
            }
            else if (dright && dleft)//if both diagonals free
            {//randomly choose one
                if (r.Next(2) == 1)
                {
                    swapElems(x, y, x + 1, y + 1);//down right
                }
                else
                {
                    swapElems(x, y, x - 1, y + 1);//down left
                }
            }
            else if (dright)//down right
            {
                swapElems(x, y, x + 1, y + 1);
            }
            else if (dleft)//down left
            {
                swapElems(x, y, x - 1, y + 1);
            }

        }
        //liquids should be able to travel more than one cell horizontally
        //this makes them disperse faster and more realistically
        private void disperseLiquid(int x, int y, Element elem, bool isRight)
        {
            List<Point> path;
            if (isRight)
            {
                path = getPath(x, y, x + elem.liquidDispersionRate, y);
            }
            else
            {
                path = getPath(x, y, x - elem.liquidDispersionRate, y);
            }

            Point endPos = new Point(x, y);
            foreach (Point p in path)
            {
                if (p.X >= 0 && p.X < world.sizeX && 
                    (world.worldArray[p.X, p.Y].state == "Empty" || 
                    (world.worldArray[p.X, p.Y].state == "Liquid" && world.worldArray[p.X, p.Y].name != elem.name)))
                {
                    endPos = p;
                }
                else
                {
                    break;
                }
            }
            world.worldArray[x, y].isProcessed = true;
            swapElems(x, y, endPos.X, endPos.Y);
        }
        private void updateLiquid(int x, int y, Element elem)
        {

            //if at bottom of screen
            if (elem.isProcessed)
            {
                return;
            }
            bool down = y + 1 != world.sizeY && (world.worldArray[x, y + 1].state == "Empty" || world.worldArray[x, y + 1].state == "Gas");
            bool dright = x + 1 != world.sizeX && y + 1 != world.sizeY && (world.worldArray[x + 1, y + 1].state == "Empty" || world.worldArray[x + 1, y + 1].state == "Gas");
            bool dleft = x != 0 && y + 1 != world.sizeY && (world.worldArray[x - 1, y + 1].state == "Empty" || world.worldArray[x - 1, y + 1].state == "Gas");

            bool right = x + 1 != world.sizeX && (world.worldArray[x + 1, y].state == "Empty" || 
                        (world.worldArray[x + 1, y].name != elem.name && world.worldArray[x + 1, y].state == "Liquid"));
            bool left = x != 0 && (world.worldArray[x - 1, y].state == "Empty" || 
                        (world.worldArray[x - 1, y].name != elem.name && world.worldArray[x - 1, y].state == "Liquid"));


            if (elem.name == "Water" && y + 1 != world.sizeY && world.worldArray[x, y + 1].name == "Oil")
            {
                down = true;
            }
            //lava should set elements alight and turn water into obsidian
            if (elem.name == "Lava")
            {
                //down
                if (y + 1 != world.sizeY)
                {
                    setAlight(x, y + 1);
                    if (world.worldArray[x, y + 1].name == "Water")
                    {
                        world.worldArray[x, y + 1] = generateElement("obsidian");
                    }
                }
                //right
                if (x + 1 != world.sizeX)
                {
                    setAlight(x + 1, y);
                    if (world.worldArray[x + 1, y].name == "Water")
                    {
                        world.worldArray[x + 1, y] = generateElement("obsidian");
                    }
                }
                //left
                if (x != 0)
                {
                    setAlight(x - 1, y);
                    if (world.worldArray[x - 1, y].name == "Water")
                    {
                        world.worldArray[x - 1, y] = generateElement("obsidian");
                    }
                }
                //down
                if (y != 0)
                {
                    setAlight(x, y - 1);
                    if (world.worldArray[x, y - 1].name == "Water")
                    {
                        world.worldArray[x, y - 1] = generateElement("obsidian");
                    }
                }
            }
            //fall if can
            if (down)
            {

                //swap current particle and the one below it
                swapElems(x, y, x, y + 1);
            }
            else if (dright && dleft)//if both diagonals free
            {//randomly choose one
                if (r.Next(2) == 1)
                {
                    swapElems(x, y, x + 1, y + 1);//down right
                }
                else
                {
                    swapElems(x, y, x - 1, y + 1);//down left
                }
            }
            else if (dright)
            {
                swapElems(x, y, x + 1, y + 1);//down right
            }
            else if (dleft)
            {
                swapElems(x, y, x - 1, y + 1);//down left
            }
            else if (right && left)//if both diagonals free
            {//randomly choose one to travel to
                int rand = r.Next(3);
                if (rand == 1)
                {
                    disperseLiquid(x, y, elem, true);//right
                }
                else if (rand == 0)
                {
                    disperseLiquid(x, y, elem, false);//left

                }
            }
            else if (right)
            {
                disperseLiquid(x, y, elem, true);//right
            }
            else if (left)
            {
                disperseLiquid(x, y, elem, false);//left
            }

            elem.isProcessed = true;
        }

        private void updateGas(int x, int y, Element elem)
        {
            //if at bottom of screen
            if (elem.isProcessed)
            {
                return;
            }
            bool up = y != 0 && world.worldArray[x, y - 1].state == "Empty";
            bool uright = y != 0 && x + 1 != world.sizeX && world.worldArray[x + 1, y - 1].state == "Empty";
            bool uleft = y != 0 &&  x != 0 && world.worldArray[x - 1, y - 1].state == "Empty";
            bool right = x + 1 != world.sizeX && world.worldArray[x + 1, y].state == "Empty";
            bool left = x != 0 && world.worldArray[x - 1, y].state == "Empty";
            //rise if can
            if (uleft && uright)
            {
                int rand = r.Next(3);
                switch (rand)
                {
                    case 1:
                        swapElems(x, y, x + 1, y - 1);//down right
                        break;
                    case 2:
                        swapElems(x, y, x - 1, y - 1);//down left
                        break;
                    default:
                        swapElems(x, y, x, y - 1);
                        break;

                }
            }
            else if (up)
            {
                //swap current particle and the one below it
                swapElems(x, y, x, y - 1);
            }
            else if (uright)
            {
                swapElems(x, y, x + 1, y - 1);//up right
            }
            else if (uleft)
            {
                swapElems(x, y, x - 1, y - 1);//up left
            }
            else if (right && left)//if both diagonals free
            {//randomly choose one to travel to
                int rand = r.Next(3);
                if (rand == 1)
                {
                    swapElems(x, y, x + 1, y);//right
                }
                else if (rand == 0)
                {
                    swapElems(x, y, x - 1, y);//left

                }
            }
            else if (right)
            {
                swapElems(x, y, x + 1, y);//right
            }
            else if (left)
            {
                swapElems(x, y, x - 1, y);//left
            }

            elem.isProcessed = true;
        }

        private void spreadFireTo(int x, int y)
        {
            Element elem = world.worldArray[x, y];

            //Explosive elements
            if (elem.name == "Gunpowder")
            {
                explodeRadius(x, y, r.Next(3, 7));
            }
            else if (elem.name == "C4")
            {
                explodeRadius(x, y, r.Next(20, 50));
            }
            else if (elem.name == "Nitroglycerin")
            {
                explodeRadius(x, y, r.Next(30, 60));
            }
            //Meltable Elements
            else if (elem.name == "Ice" || elem.name == "Snow")
            {
                world.worldArray[x, y] = generateElement("water");
            }
            //Flammable Elements
            else
            {
                world.worldArray[x, y] = generateElement("fire");
            }
        }
        private void createGas(int x, int y)
        {
            //Amount of smoke generated should be proportional to flammability
            if (r.Next(100) < world.worldArray[x, y].flammability/3)
            {
                world.worldArray[x, y] = generateElement("smoke");
            }
            
        }
        private bool setAlight(int x, int y)
        {
            bool hasSpread = false;
            int spreadChance = r.Next(100);
            //down
            if (y + 1 != world.sizeY)
            {
                //random chance to spread based on flammability
                if (spreadChance < world.worldArray[x, y + 1].flammability)
                {
                    if (r.Next(100) < 75)
                    {
                        spreadFireTo(x, y + 1);
                    }
                    //random chance to emit smoke if does not burn
                    else if (world.worldArray[x, y + 1].canSmoke)
                    {
                        createGas(x, y + 1);
                    }
                    hasSpread = true;
                }
            }
            spreadChance = r.Next(100);
            //right
            if (x + 1 != world.sizeX)
            {
                //random chance to spread based on flammability
                if (spreadChance < world.worldArray[x + 1, y].flammability)
                {
                    if (r.Next(100) < 75)
                    {
                        spreadFireTo(x + 1, y);
                    }
                    //random chance to emit smoke if does not burn
                    else if (world.worldArray[x + 1, y].canSmoke)
                    {
                        createGas(x + 1, y);
                    }
                    hasSpread = true;
                }
            }
            spreadChance = r.Next(100);
            //left
            if (x != 0)
            {
                //random chance to spread based on flammability
                if (spreadChance < world.worldArray[x - 1, y].flammability)
                {
                    if (r.Next(100) < 75)
                    {
                        spreadFireTo(x - 1, y);
                    }
                    //random chance to emit smoke if does not burn
                    else if (world.worldArray[x - 1, y].canSmoke)
                    {
                        createGas(x - 1, y);
                    }
                    hasSpread = true;
                }
            }
            spreadChance = r.Next(100);
            //up
            if (y != 0)
            {
                //random chance to spread based on flammability
                if (spreadChance < world.worldArray[x, y - 1].flammability)
                {
                    if (r.Next(100) < 75)
                    {
                        spreadFireTo(x, y - 1);
                    }
                    //random chance to emit smoke if does not burn
                    else if (world.worldArray[x, y - 1].canSmoke)
                    {
                        createGas(x, y - 1);
                    }
                    hasSpread = true;
                }
            }
            return hasSpread;
        }


        private void explodePath(List<Point> path, int startX, int startY)
        {
            Element e;
            
            
            Point line = new Point((path[path.Count - 1].X-startX), (path[path.Count - 1].Y - startY));

            //euclidean length of path
            double length = Math.Sqrt(line.X * line.X + line.Y * line.Y);

            //unit vector representing direction of path
            Point direction = new Point(Convert.ToInt32(line.X / (length + 0.001)), Convert.ToInt32(line.Y / (length + 0.001)));

            int index = 1;
            int darkenAmount = 20;
            bool exploding = true;

            //loop through path
            foreach (Point p in path)
            {
                //if out of bounds, return
                if (p.X < 0 || p.X >= world.sizeX || p.Y < 0 || p.Y >= world.sizeY)
                {
                    return;
                }

                e = world.worldArray[p.X, p.Y];

                if (exploding)
                {
                    //random chance to stop path based on explosionResistance
                    if (r.Next(0, 100) > e.explosionResistance)
                    {
                        //create fire and project it in direction of path
                        if (r.Next(1, 4) == 1)
                        {
                            world.worldArray[p.X, p.Y] = generateElement("fire");
                            world.worldArray[p.X, p.Y].isProjectile = true;
                            world.worldArray[p.X, p.Y].xVelocity += direction.X;
                            world.worldArray[p.X, p.Y].yVelocity += direction.Y;
                        }
                        //project particle in direction of path if not exploded
                        else if (world.worldArray[p.X, p.Y].state != "Immovable" && world.worldArray[p.X, p.Y].state != "Fire" && world.worldArray[p.X, p.Y].state != "Empty")
                        {
                            world.worldArray[p.X, p.Y].isProjectile = true;
                            world.worldArray[p.X, p.Y].xVelocity += direction.X * 2;
                            world.worldArray[p.X, p.Y].yVelocity += direction.Y * 2;
                        }
                        else
                        {
                            world.worldArray[p.X, p.Y] = generateElement("air");
                        }
                    }
                    else
                    {
                        exploding = false;
                    }
                }
                else
                {
                    //darken pixels after explosion done
                    int red = world.worldArray[p.X, p.Y].colour.R - darkenAmount;
                    int green = world.worldArray[p.X, p.Y].colour.G - darkenAmount;
                    int blue = world.worldArray[p.X, p.Y].colour.B - darkenAmount;
                    red = Math.Abs(red);
                    green = Math.Abs(green);
                    blue = Math.Abs(blue);
                    world.worldArray[p.X, p.Y].colour = Color.FromArgb(red, green, blue);
                    darkenAmount -= r.Next(1,4);

                    //darkenAmount should never be less than 0
                    darkenAmount = Math.Abs(darkenAmount);
                }

                index++;
            }
        }
        private void explodeRadius(int startX, int startY, int radius)
        {
            List<Point> path;
            radius = Convert.ToInt32(radius / 1.5);
            explodePath(new List<Point> { new Point(startX, startY) },startX,startY);
            if (radius <= 1)
            {
                return;
            }
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    //create an outline of a circle
                    if (x * x + y * y <= (radius + 1) * (radius + 1) && x * x + y * y >= (radius - 1) * (radius - 1))
                    {
                        //explode a path from the origin of the explosion to the radius
                        path = getPath(startX, startY, x + startX, y + startY);
                        explodePath(path, startX, startY);
                    }
                }
            }
        }

        private void updateFire(int x, int y, Element elem)
        {
            bool spread = setAlight(x, y);

            //fire should have a chance to burn out every frame
            int deathChance = r.Next(100);
            if (deathChance <= 30 && !spread)
            {
                world.worldArray[x, y] = generateElement("air");
            }
        }

        private void tmrTick_Tick(object sender, EventArgs e)//run every timestep
        {
            //place elements where mouse is
            if (mouseDown && selectedElement != "explosion")
            {
                drawPath();
            }


            //update display bitmap
            drawWorld();
            //push bitmap to picturebox
            Graphics pctGraphics = pctDisplay.CreateGraphics();
            pctGraphics.DrawImage(displayBmp, 0, 0);

            //dispose of objects
            pctGraphics.Dispose();
            displayBmp.Dispose();

            if (!paused)
            {
                //update world for next timestep
                updateWorld();

            }

        }

        private Color HSVToRGB(int h, int s, int v)
        {
            var rgb = new int[3];

            var baseColor = (h + 60) % 360 / 120;
            var shift = (h + 60) % 360 - (120 * baseColor + 60);
            var secondaryColor = (baseColor + (shift >= 0 ? 1 : -1) + 3) % 3;

            //set hue (from 0 to 360)
            rgb[baseColor] = 255;
            rgb[secondaryColor] = (int)((Math.Abs(shift) / 60.0f) * 255.0);

            //set saturation (from 0 to 100)
            for (var i = 0; i < 3; i++)
            {
                rgb[i] += (int)((255 - rgb[i]) * ((100 - s) / 100.0));
            }

            //set value (from 0 to 100) - represents brightness
            for (var i = 0; i < 3; i++)
            {
                rgb[i] -= (int)(rgb[i] * (100 - v) / 100.0);
            }

            int r = rgb[0];
            int g = rgb[1];
            int b = rgb[2];
            return Color.FromArgb(r, g, b);
        }

        private Color rainbowColour()
        {
            return HSVToRGB(r.Next(0, 360), r.Next(70,101), 100);
        }

        private Element generateElement(string name)
        {
            Element e;
            int c;

            //generate elements based on name of element
            switch (name)
            {
                case "sand":
                    c = r.Next(230, 255);
                    e = new Element("Sand", "Solid", Color.FromArgb(c, c-30, c-210), Flammability: 0);
                    break;
                case "water":
                    e = new Element("Water", "Liquid", Color.FromArgb(0, r.Next(20, 60), r.Next(230, 255)), r.Next(1, 4), Flammability: 0);
                    break;
                case "oil":
                    c = r.Next(0, 10);
                    e = new Element("Oil", "Liquid", Color.FromArgb(c, c, c), r.Next(1, 2), Flammability: 70);
                    break;
                case "lava":
                    e = new Element("Lava", "Liquid", Color.FromArgb(210, r.Next(40, 60), 10), 1);
                    break;
                case "stone":
                    c = r.Next(60, 80);
                    e = new Element("Stone", "Immovable", Color.FromArgb(c, c, c + 20), ExplosionResistance:10);
                    break;
                case "obsidian":
                    c = r.Next(0, 25);
                    e = new Element("Obsidian", "Immovable", Color.FromArgb(c, c, c + 20), ExplosionResistance: 100);
                    break;
                case "balls":
                    e = new Element("Balls", "Solid", rainbowColour(), 1, 0.9, Flammability: 30);
                    e.isProjectile = true;
                    e.yVelocity = r.Next(-3, 3);
                    e.xVelocity = r.Next(-3, 3);
                    break;
                case "wood":
                    e = new Element("Wood", "Immovable", Color.FromArgb(r.Next(50, 70), r.Next(20, 30), 10), Flammability: 35);
                    break;
                case "fire":
                    e = new Element("Fire", "Fire", Color.FromArgb(r.Next(210, 230), r.Next(60, 90), 20));
                    break;
                case "gravel":
                    c = r.Next(50, 100);
                    e = new Element("Gravel", "Solid", Color.FromArgb(c, c, c), Flammability: 0, ExplosionResistance:30);
                    break;
                case "gunpowder":
                    c = r.Next(30, 40);
                    e = new Element("Gunpowder", "Solid", Color.FromArgb(c, c, c), Flammability: 60, ExplosionResistance: 30);
                    break;
                case "c4":
                    c = r.Next(0, 2);
                    e = new Element("C4", "Immovable", Color.FromArgb(232-10*c, 190-10*c, 110-10*c), Flammability: 90, ExplosionResistance: 50);
                    break;
                case "nitroglycerin":
                    c = r.Next(220,230);
                    e = new Element("Nitroglycerin", "Liquid", Color.FromArgb(c,c,c),dispersionRate: r.Next(1, 4), Flammability: 70, ExplosionResistance: 50);
                    break;
                case "dust":
                    e = new Element("Sand", "Solid", HSVToRGB(dustHue, r.Next(70, 90), 80), Flammability: 20);
                    break;
                case "ice":
                    c = r.Next(0, 10);
                    e = new Element("Ice", "Immovable", Color.FromArgb(131, 205+c, 252), Flammability: 50, CanSmoke: false);
                    break;
                case "snow":
                    c = r.Next(-15, 15);
                    e = new Element("Snow", "Solid", Color.FromArgb(200 + c, 225 + c, 255), Flammability: 50, CanSmoke: false);
                    break;
                case "smoke":
                    c = r.Next(80,90);
                    e = new Element("Smoke", "Gas", Color.FromArgb(c, c, c), DoesRise:true);
                    break;
                default:
                    e = new Element("Air", "Empty", Color.White, Flammability: 2);
                    break;
            }
            return e;
        }
        private void drawPath()
        {

            int mouseX = mouseInfo.Location.X / cellSize;
            int mouseY = mouseInfo.Location.Y / cellSize;


            if (mouseX > world.sizeX - 1 | mouseY > world.sizeY - 1)
            {
                return;
            }
            if(selectedElement == "dust")
            {
                dustHue += 2;
                dustHue = dustHue % 360;
            }
            if (brushMode == "circle")
            {
                fillCircle(selectedElement, trbBrushSize.Value, mouseX, mouseY);
            }
            else
            {
                fillSquare(selectedElement, trbBrushSize.Value, mouseX, mouseY);
            }
            
        }
        private void fillSquare(string elemName,int size,int startX, int startY)
        {
            //centre square on start pos by offsetting it by half of square size
            startX -= size / 2;
            startY -= size / 2;
            //loop through every cell in square
            for (int y = startY; y < startY+size; y++)
            {
                for (int x = startX; x < startX + size; x++)
                {
                    if (x >= 0 && x < world.sizeX && y >= 0 && y < world.sizeY)
                    {
                        if (chbOverwrite.Checked || world.worldArray[x, y].state == "Empty" || selectedElement == "air") { 
                            world.worldArray[x, y] = generateElement(elemName);//fill pixel with new element
                        }
                    }
                }
            }
        }
        private void fillCircle(string elemName, int radius, int startX, int startY)
        {
            radius /= 2;

            if (radius == 0 && startX >= 0 && startY >= 0 && startX < world.sizeX && startY < world.sizeY)
            {
                if (chbOverwrite.Checked || world.worldArray[startX, startY].state == "Empty" || selectedElement == "air")
                {
                    world.worldArray[startX, startY] = generateElement(elemName);
                }
            }

            //centre circle on start pos by offsetting it by half of square size
            //loop through every cell in square
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    //if x^2 + y^2 less than or equal to radius^2 then fill pixel
                    //this creates a circle
                    if(x*x + y*y <= radius *radius &&
                        x + startX >= 0 && y + startY >= 0 && x+startX < world.sizeX && y+startY < world.sizeY)
                    {
                        //if(x*x + )
                        //only fill pixel if overwrite enabled or 
                        if(chbOverwrite.Checked || world.worldArray[x + startX, y + startY].state == "Empty" || selectedElement == "air")
                        {
                            world.worldArray[x + startX, y + startY] = generateElement(elemName);//fill pixel with new element
                        }
                    }
                }
            }
        }
        private void pctDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedElement == "explosion")
            {
                int mouseX = e.Location.X / cellSize;
                int mouseY = e.Location.Y / cellSize;

                if (mouseX > world.sizeX - 1 | mouseY > world.sizeY - 1)
                {
                    return;
                }
                explodeRadius(mouseX, mouseY, trbBrushSize.Value);
                return;
            }
            mouseInfo = e;
            mouseDown = true;
        }
        private void pctDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void pctDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedElement != "explosion")
            {
                pctDisplay_MouseDown(sender, e);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            world.generateWorld();
        }

        private void btnSand_Click(object sender, EventArgs e)
        {
            selectedElement = "sand";
        }

        private void btnWater_Click(object sender, EventArgs e)
        {
            selectedElement = "water";
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            selectedElement = "air";
        }

        private void btnStone_Click(object sender, EventArgs e)
        {
            selectedElement = "stone";
        }

        private void btnBalls_Click(object sender, EventArgs e)
        {
            selectedElement = "balls";
        }

        private void btnWood_Click(object sender, EventArgs e)
        {
            selectedElement = "wood";
        }

        private void btnLava_Click(object sender, EventArgs e)
        {
            selectedElement = "lava";
        }

        private void btnFire_Click(object sender, EventArgs e)
        {
            selectedElement = "fire";
        }

        private void btnOil_Click(object sender, EventArgs e)
        {
            selectedElement = "oil";
        }

        private void btnGravel_Click(object sender, EventArgs e)
        {
            selectedElement = "gravel";
        }
        private void btnExplode_Click(object sender, EventArgs e)
        {
            selectedElement = "explosion";
        }
        private void btnObsidian_Click(object sender, EventArgs e)
        {
            selectedElement = "obsidian";
        }
        private void btnGunpowder_Click(object sender, EventArgs e)
        {
            selectedElement = "gunpowder";
        }
        private void btnC4_Click(object sender, EventArgs e)
        {
            selectedElement = "c4";
        }
        private void btnNitroglycerin_Click(object sender, EventArgs e)
        {
            selectedElement = "nitroglycerin";
        }
        private void btnDust_Click(object sender, EventArgs e)
        {
            selectedElement = "dust";
        }
        private void btnIce_Click(object sender, EventArgs e)
        {
            selectedElement = "ice";
        }
        private void btnSnow_Click(object sender, EventArgs e)
        {
            selectedElement = "snow";
        }
        private void btnSmoke_Click(object sender, EventArgs e)
        {
            selectedElement = "smoke";
        }
        private void btnPaused_Click(object sender, EventArgs e)
        {
            paused = !paused;
            // should only be able to step through time when paused
            btnStep.Enabled = paused;
            lblPaused.Visible = paused;
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            //draw stuff
            drawWorld();
            Graphics pctGraphics = pctDisplay.CreateGraphics();
            pctGraphics.DrawImage(displayBmp, 0, 0);

            //dispose of objects
            pctGraphics.Dispose();
            displayBmp.Dispose();

            //update world for next timestep
            updateWorld();
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            brushMode = "circle";
            getPath(0, 0, 5, 10);
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            brushMode = "square";
        }

        //when theme changed
        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTheme.SelectedIndex)
            {
                case 0:
                    currentTheme = "light";
                    BackColor = Color.White;

                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    lblSize.ForeColor = Color.Black;

                    cmbTheme.BackColor = Color.White;
                    cmbTheme.ForeColor = Color.Black;

                    chbOverwrite.ForeColor = Color.Black;

                    btnPaused.BackColor = Color.FromArgb(255, 78, 75);
                    btnReset.BackColor = Color.FromArgb(255, 78, 75);
                    break;

                case 1:
                    currentTheme = "dark";
                    BackColor = Color.FromArgb(0, 0, 0);

                    label1.ForeColor = Color.FromArgb(193, 189, 179);
                    label2.ForeColor = Color.FromArgb(193, 189, 179);
                    label3.ForeColor = Color.FromArgb(193, 189, 179);
                    lblSize.ForeColor = Color.FromArgb(193, 189, 179);
                    lblPaused.ForeColor = Color.FromArgb(193, 189, 179);

                    cmbTheme.BackColor = Color.FromArgb(12, 24, 33);
                    cmbTheme.ForeColor = Color.FromArgb(193, 189, 179);

                    chbOverwrite.ForeColor = Color.FromArgb(193, 189, 179);
                    break;
                case 2:
                    currentTheme = "colourful";
                    BackColor = Color.FromArgb(0, 0, 0);

                    label1.ForeColor = Color.FromArgb(193, 189, 179);
                    label2.ForeColor = Color.FromArgb(193, 189, 179);
                    label3.ForeColor = Color.FromArgb(193, 189, 179);
                    lblSize.ForeColor = Color.FromArgb(193, 189, 179);
                    lblPaused.ForeColor = Color.FromArgb(193, 189, 179);

                    cmbTheme.BackColor = Color.FromArgb(12, 24, 33);
                    cmbTheme.ForeColor = Color.FromArgb(193, 189, 179);

                    chbOverwrite.ForeColor = Color.FromArgb(193, 189, 179);
                    break;
            }
            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    switch (currentTheme)
                    {
                        case "light":
                            control.BackColor = Color.WhiteSmoke;
                            control.ForeColor = Color.Black;
                            break;

                        case "dark":
                            control.BackColor = Color.FromArgb(12, 24, 33);
                            control.ForeColor = Color.FromArgb(193, 189, 179);
                            btnPaused.BackColor = Color.FromArgb(255, 78, 75);
                            btnReset.BackColor = Color.FromArgb(255, 78, 75);

                            btnPaused.ForeColor = Color.Black;
                            btnReset.ForeColor = Color.Black;
                            break;
                        case "colourful":
                            control.BackColor = rainbowColour();
                            control.ForeColor = Color.Black;

                            btnPaused.ForeColor = Color.Black;
                            btnReset.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void trbSize_ValueChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int newSize = 3;
            switch (trbSize.Value)
            {
                case (5):
                    newSize = 2;
                    break;
                case (4):
                    newSize = 3;
                    break;
                case (3):
                    newSize = 4;
                    break;
                case (2):
                    newSize = 5;
                    break;
                case (1):
                    newSize = 10;
                    break;
            }
            if (newSize != cellSize)
            {
                cellSize = newSize;
                int worldWidth = pctDisplay.Width / cellSize;
                int worldHeight = pctDisplay.Height / cellSize;

                worldXOffset = (pctDisplay.Width % cellSize) / 2;
                worldYOffset = (pctDisplay.Height % cellSize) / 2;

                world = new World(worldWidth, worldHeight);
                world.generateWorld();
            }
            btnApply.Enabled = false;
        }
    }
}