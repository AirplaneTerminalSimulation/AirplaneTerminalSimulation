using System;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;

//
//  Bermuda Triangle : Version 16
//
public class Form1 : Form
{

    private Container components = null;
    private ButtonPanelThread p1, p3;
    private Button btn1, btn3;
    private WaitPanelThread p2;
    private Thread thread1, thread2, thread3;
    private Semaphore semaphore;
    private Buffer buffer;
    private Thread semThread;
    private Thread buffThread;
    private Panel pnl1, pnl2, pnl3;


    public Form1()
    {
        InitializeComponent();


        semaphore = new Semaphore();
        buffer = new Buffer();


        p1 = new ButtonPanelThread(new Point(40, 10),
                             120, true, pnl1,
                             Color.Blue,
                             semaphore,
                             buffer,
                             btn1);

        p2 = new WaitPanelThread(new Point(40, 10),
                             100, true, pnl2,
                             Color.White,
                             semaphore,
                             buffer);

        p3 = new ButtonPanelThread(new Point(40, 10),
                             250, true, pnl3,
                             Color.Red,
                             semaphore,
                             buffer,
                             btn3);


        semThread = new Thread(new ThreadStart(semaphore.Start));
        buffThread = new Thread(new ThreadStart(buffer.Start));
        thread1 = new Thread(new ThreadStart(p1.Start));
        thread2 = new Thread(new ThreadStart(p2.Start));
        thread3 = new Thread(new ThreadStart(p3.Start));


        this.Closing += new CancelEventHandler(this.Form1_Closing);

        semThread.Start();
        buffThread.Start();
        thread1.Start();
        thread2.Start();
        thread3.Start();

    }


    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
                components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.Text = "Bermuda Triangle Airways";
        this.Size = new System.Drawing.Size(700, 500);
        this.BackColor = Color.LightGray;
        //this.BackgroundImage =Image.FromFile(@".\stone.gif");

        this.pnl1 = new Panel();
        this.pnl1.Location = new Point(100, 100);
        this.pnl1.Size = new Size(260, 30);
        this.pnl1.BackColor = Color.White;

        this.btn1 = new Button();
        this.btn1.Size = new Size(30, 30);
        this.btn1.BackColor = Color.Pink;
        this.btn1.Location = new System.Drawing.Point(0, 0);


        this.pnl2 = new Panel();
        this.pnl2.Location = new Point(370, 200);
        this.pnl2.Size = new Size(260, 30);
        this.pnl2.BackColor = Color.White;
        //this.pnl2.BackgroundImage =Image.FromFile(@".\stone.gif");


        this.pnl3 = new Panel();
        this.pnl3.Location = new Point(100, 320);
        this.pnl3.Size = new Size(260, 30);
        this.pnl3.BackColor = Color.White;

        this.btn3 = new Button();
        this.btn3.Size = new Size(30, 30);
        this.btn3.BackColor = Color.Pink;
        this.btn3.Location = new System.Drawing.Point(0, 0);


        this.Controls.Add(pnl1);
        this.Controls.Add(pnl2);
        this.Controls.Add(pnl3);
        this.pnl1.Controls.Add(btn1);
        this.pnl3.Controls.Add(btn3);

        // Wire Closing event.      
        this.Closing += new CancelEventHandler(this.Form1_Closing);
    }

    private void Form1_Closing(object sender, CancelEventArgs e)
    {
        // Environment is a System class.
        // Kill off all threads on exit.
        Environment.Exit(Environment.ExitCode);
    }


}// end class form1


public class Buffer
{
    private Color planeColor;
    private bool empty = true;

    public void Read(ref Color planeColor)
    {
        lock (this)
        {
            // Check whether the buffer is empty.
            if (empty)
                Monitor.Wait(this);
            empty = true;
            planeColor = this.planeColor;
            Monitor.Pulse(this);
        }
    }

    public void Write(Color planeColor)
    {
        lock (this)
        {
            // Check whether the buffer is full.
            if (!empty)
                Monitor.Wait(this);
            empty = false;
            this.planeColor = planeColor;
            Monitor.Pulse(this);
        }
    }

    public void Start()
    {
    }

}// end class Buffer

public class Semaphore
{
    private int count = 0;

    public void Wait()
    {
        lock (this)
        {
            while (count == 0)
                Monitor.Wait(this);
            count = 0;
        }
    }

    public void Signal()
    {
        lock (this)
        {
            count = 1;
            Monitor.Pulse(this);
        }
    }

    public void Start()
    {
    }

}// end class Semaphore

public class ButtonPanelThread
{
    private Point origin;
    private int delay;
    private Panel panel;
    private bool westEast;
    private Color colour;
    private Point plane;
    private int xDelta;
    private int yDelta;
    private Semaphore semaphore;
    private Buffer buffer;
    private Button btn;
    private bool locked = true;



    public ButtonPanelThread(Point origin,
                             int delay,
                             bool westEast,
                             Panel panel,
                             Color colour,
                             Semaphore semaphore,
                             Buffer buffer,
                             Button btn)
    {
        this.origin = origin;
        this.delay = delay;
        this.westEast = westEast;
        this.panel = panel;
        this.colour = colour;
        this.plane = origin;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.xDelta = westEast ? +10 : -10;
        this.yDelta = 0;
        this.semaphore = semaphore;
        this.buffer = buffer;
        this.btn = btn;
        this.btn.Click += new System.
                              EventHandler(this.btn_Click);


    }

    private void btn_Click(object sender,
                           System.EventArgs e)
    {
        locked = !locked;
        this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;
        lock (this)
        {
            if (!locked)
                Monitor.Pulse(this);
        }
    }

    public void Start()
    {
        Color signal = Color.Red;
        Thread.Sleep(delay);


        for (int k = 1; k <= 6; k++)
        {
            this.zeroPlane();
            panel.Invalidate();
            lock (this)
            {
                while (locked)
                {
                    Monitor.Wait(this);
                }
            }
            for (int i = 1; i <= 20; i++)
            {
                this.movePlane(xDelta, yDelta);
                Thread.Sleep(delay);
                panel.Invalidate();
            }
            semaphore.Wait();
            buffer.Write(this.colour);
        }
        this.colour = Color.Gray;
        panel.Invalidate();
    }

    private void zeroPlane()
    {
        plane.X = origin.X;
        plane.Y = origin.Y;
    }

    private void movePlane(int xDelta, int yDelta)
    {
        plane.X += xDelta; plane.Y += yDelta;
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        SolidBrush brush = new SolidBrush(colour);
        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);

        brush.Dispose();    //  Dispose graphics resources. 
        g.Dispose();        //  
    }
}// end class ButtonPanelThread

public class WaitPanelThread
{
    private Point origin;
    private int delay;
    private Panel panel;
    private bool westEast;
    private Color colour;
    private Point plane;
    private int xDelta;
    private int yDelta;
    private Semaphore semaphore;
    private Buffer buffer;


    public WaitPanelThread(Point origin,
                       int delay,
                       bool westEast,
                       Panel panel,
                       Color colour,
                       Semaphore semaphore,
                       Buffer buffer)
    {
        this.origin = origin;
        this.delay = delay;
        this.westEast = westEast;
        this.panel = panel;
        this.colour = colour;
        this.plane = origin;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.xDelta = westEast ? +10 : -10;
        this.yDelta = 0;
        this.semaphore = semaphore;
        this.buffer = buffer;

    }

    public void Start()
    {

        //Thread.Sleep(delay);
        this.colour = Color.White;
        for (int k = 1; k <= 12; k++)
        {
            semaphore.Signal();
            this.zeroPlane();

            buffer.Read(ref this.colour);

            for (int i = 1; i <= 20; i++)
            {

                panel.Invalidate();
                this.movePlane(xDelta, yDelta);
                Thread.Sleep(delay);

            }
            this.colour = Color.White;
            panel.Invalidate();


        }
        this.colour = Color.Gray;
        panel.Invalidate();
    }

    private void zeroPlane()
    {
        plane.X = origin.X;
        plane.Y = origin.Y;
    }

    private void movePlane(int xDelta, int yDelta)
    {
        plane.X += xDelta; plane.Y += yDelta;
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        SolidBrush brush = new SolidBrush(colour);
        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);
        brush.Dispose();    //  Dispose graphics resources. 
        g.Dispose();        //  
    }
}// end class WaitPanelThread

public class TheOne
{
    public static void Main()//
    {

        Application.Run(new Form1());
    }
}// end class TheOne

