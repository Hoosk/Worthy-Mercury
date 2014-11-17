using AwesomeGame.Properties;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

public class Brick
{
    private int vidas;
    private PictureBox brick;  
    ResourceManager rm = Resources.ResourceManager;           
    private String[] tipos = new String [3];
    
    //size -> ClientSize.Width
    //rm -> (Bitmap)rm.GetObject("red")
	public Brick(int xbrickX, int xbrickY, int size, int vidas )
	{
        this.tipos[0] = "red";
        this.tipos[1] = "grey";
        this.tipos[2] = "gold";
        this.brick = new PictureBox(); 
        this.brick.Location = new Point(xbrickX, xbrickY);
        this.brick.Image = (Bitmap)rm.GetObject(this.tipos[0]);
        this.brick.SizeMode = PictureBoxSizeMode.StretchImage;
        this.brick.ClientSize = new Size(( size / 5), 20);
        this.vidas = vidas;
        
	}

    public void delete()
    {
        this.brick.Dispose();
        this.brick.SendToBack();
        this.brick.SetBounds(0, 0, 0, 0);
    }

    public void hurtMe()
    {
        if(this.vidas >= 0){
            --this.vidas;
            switch(this.vidas){
                case 2:
                    this.brick.Image = (Bitmap)rm.GetObject(this.tipos[1]);
                    break;
                case 1:
                    this.brick.Image = (Bitmap)rm.GetObject(this.tipos[2]);
                    break;
            }
            
        }        
    }


    public Boolean imBroken()
    {
        Boolean imBroken = false;
        if (this.vidas <= 0)
        {
            imBroken = true;
        }
        return imBroken;
    }

    public PictureBox whoami()
    {
        return this.brick;
    }

    public String toString()
    {
        return "Soy un triste ladrillo :(";
    }

}
