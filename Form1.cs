using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AwesomeGame.Properties;
using System.Threading;
namespace AwesomeGame
{
    /*Adventure Time!!
     * 
     *   | (• ◡•)| (❍ᴥ❍ʋ)
     *   
           /|________________
     O|===|*>________________ >
           \|  
     * 
     *  Take your sword and debug!
     */

    /* = TODO LIST:
     * - Testear y arreglar bugs tontos.
     *  -Ahora ya acaba partida (crear metodo nextlvl).
     *  -Que cada nivel sea mas complejo
    * - Arreglar mas bugs tontos.
     */
    public partial class Form1 : Form
    {
        
        /*Variables de posicion para la pala y la pelota y esas cosas*/
        static int x ;
        static int y ;
        static int dx;
        static int dy;

        /*Objetos de imagenes */
        ResourceManager rm = Resources.ResourceManager;

        /*Random*/
        static Random rand = new Random();

        /*Variables de velocidad*/
        static int velocidadx = 4;
        static int velocidady = -4;

        /*Vidas*/
        static int vidas = 3;
        /*Cantidad de filas y columnas*/
        static int filas = 3;
        static int columnas = 5;
        /*variables de ladrillos*/
        Brick[,] bloc = new Brick[4, 10];
        static int numeroLadrillos = filas * columnas;
        static int xx = 0;
        static int yy = 25;
        /*Vanity vars*/
        static int puntuacion = 0;


        public Form1()
        {            
            InitializeComponent();       
            timer1.Interval = 10;
            timer2.Interval = 10;
                     
        }
      
        
        /*Funcion para crear bloques*/
        public void crearblocs()
        {
            for (int i = 1; i <= filas; i++)
            {
                for (int j = 1; j <= columnas; j++)
                {
                    bloc[i, j] = new Brick(xx, yy, ClientSize.Width, 3);
                    this.Controls.Add(bloc[i, j].whoami());
                    xx += (ClientSize.Width / 5);
                } xx = 0;
                yy += 20;
            }
        }

        /* 
         * Yo he visto KeyEvents que vosotros jamas creeríais. 
         * Servidores en llamas más allá de Orión. 
         * He visto Objective-C brillar en la oscuridad cerca de la Puerta de Visual Basic. 
         * Todos esos momentos se perderán en el tiempo como strings en la variable $temp.
         * Es hora de debugear."
         */
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {            
            switch (e.KeyChar)
            {
                case 'a':                    
                    if (x >= 0) x -= 9;                    
                    pala.Location = new Point(x,y);
                    break;
                case 'd':
                    if (x <= this.ClientSize.Width - 92)x += 9;                   
                    pala.Location = new Point(x, y);
                    break;
                    //truco para eliminar ladrillos
                case 'm':
                    cleanLadrillos();
                    break;
            }

        }
        
        /*
         * Un Timer para gobernarlos a todos, 
         * un Timer para encontrarlos,
         * un Timer para atraerlos a todos y atarlos en el dev/null. 
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Thread.Sleep(25);
            dx += velocidadx;
            dy += velocidady;
            pelota.Location = new Point(dx, dy);
            if (pelota.Location.Y >= this.ClientSize.Height)
            {
                dx = this.ClientSize.Width/2;
                dy = this.ClientSize.Height/2;
                vidas -= 1;
                velocidadx = 4;
                velocidady = -4;
                label2.Text = vidas.ToString();             
            }
            if (numeroLadrillos == 0 || vidas == 0)
            {
                endGame();
            }
        }
        /*
         * Otro Timer para gobernarlos a todos, 
         * otro Timer para encontrarlos,
         * otro Timer para atraerlos a todos y atarlos en el /tmp/trash. 
         */
        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(20);
            //Comprobacion para ver si la pelota intersecciona con la pala o el techo
            if (pelota.Bounds.IntersectsWith((pala.Bounds)) || pelota.Bounds.IntersectsWith(panel1.Bounds))
            {
                velocidady = -velocidady;
            }
            //Comprobacion para ver si la pelota intersecciona con los bordes del formulario
            if (pelota.Location.X <= 0 || pelota.Location.X >= (this.ClientSize.Width - pelota.Width))
            {
                velocidadx = -velocidadx;
            }

            //Comprobacion de bloques para ver si la pelota ha colisionado o no.
            for (int i = 1; i <= filas; i++)
            {
                for (int j = 1; j <= columnas; j++)
                {
                    if (pelota.Bounds.IntersectsWith(bloc[i, j].whoami().Bounds))
                    {
                        if (bloc[i, j].imBroken())
                        {
                            bloc[i, j].delete();
                            this.Controls.Remove(bloc[i, j].whoami());
                            numeroLadrillos -= 1;
                        }else{
                            bloc[i, j].hurtMe();
                        }
                        
                        puntuacion += 175;
                        label4.Text = puntuacion.ToString();
                        velocidady = -velocidady;
                    }
                }
            }
        }
        
        /*Press M*/
        //Paramos timers y hacemos aparecer el marcador 
        private void endGame(){
            timer1.Stop();
            timer2.Stop();
            groupBox1.Visible = true;        
        }

        private void nextLevel()
        {

        }

        //variables para iniciar juego
        public void newGame()
        {

            cleanLadrillos();
            numeroLadrillos = filas * columnas;
            vidas = 3;
            label2.Text = vidas.ToString();
            crearblocs();
            xx = 0;
            yy = 25;
            x = 238;
            y = 339;
            dx = 200;
            dy = 200;
            puntuacion = 0;
            pelota.Location = new Point(dx, dy);
            timer1.Start();
            timer2.Start();
        }
        
        //Utils:
        //Limpia el array de ladrillos
        private void cleanLadrillos()
        {
            numeroLadrillos = 0;
            for (int i = 1; i <= filas; i++)
            {
                for (int j = 1; j <= columnas; j++)
                {
                    if (bloc[i, j] != null)
                    {                        
                        this.Controls.Remove(bloc[i, j].whoami());       
                    }
                                     
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /*
         Guardamos la puntuacion y cerramos el formulario de juego al hacer click         
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Puntuaciones puntu = new Puntuaciones();
            DB datab = new DB();
            datab.save(textBox1.Text, puntuacion);
            puntu.Show();
            this.Close();  
        }

       
    }
}
