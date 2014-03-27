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
    private RunwayPanelThread p2;
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


        p1 = new ButtonPanelThread(new Point(10, 40),
                                7,
                             120, 3, pnl1,
                             Color.Blue,
                             semaphore,
                             buffer,
                             btn1);

        p2 = new RunwayPanelThread(new Point(10, 10),
                                23,
                             100, 1, pnl2,
                             Color.White,
                             semaphore,
                             buffer);

        p3 = new ButtonPanelThread(new Point(40, 10),
                                20,
                             250, 1, pnl3,
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
        this.pnl1 = new System.Windows.Forms.Panel();
        this.btn1 = new System.Windows.Forms.Button();
        this.pnl2 = new System.Windows.Forms.Panel();
        this.pnl3 = new System.Windows.Forms.Panel();
        this.btn3 = new System.Windows.Forms.Button();
        this.pnl1.SuspendLayout();
        this.pnl3.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnl1
        // 
        this.pnl1.BackColor = System.Drawing.Color.White;
        this.pnl1.Controls.Add(this.btn1);
        this.pnl1.Location = new System.Drawing.Point(370, 68);
        this.pnl1.Name = "pnl1";
        this.pnl1.Size = new System.Drawing.Size(30, 126);
        this.pnl1.TabIndex = 0;
        // 
        // btn1
        // 
        this.btn1.BackColor = System.Drawing.Color.Pink;
        this.btn1.Location = new System.Drawing.Point(0, 0);
        this.btn1.Name = "btn1";
        this.btn1.Size = new System.Drawing.Size(30, 30);
        this.btn1.TabIndex = 0;
        this.btn1.UseVisualStyleBackColor = false;
        // 
        // pnl2
        // 
        this.pnl2.BackColor = System.Drawing.Color.White;
        this.pnl2.Location = new System.Drawing.Point(370, 200);
        this.pnl2.Name = "pnl2";
        this.pnl2.Size = new System.Drawing.Size(260, 30);
        this.pnl2.TabIndex = 1;
        // 
        // pnl3
        // 
        this.pnl3.BackColor = System.Drawing.Color.White;
        this.pnl3.Controls.Add(this.btn3);
        this.pnl3.Location = new System.Drawing.Point(104, 200);
        this.pnl3.Name = "pnl3";
        this.pnl3.Size = new System.Drawing.Size(260, 30);
        this.pnl3.TabIndex = 2;
        // 
        // btn3
        // 
        this.btn3.BackColor = System.Drawing.Color.Pink;
        this.btn3.Location = new System.Drawing.Point(0, 0);
        this.btn3.Name = "btn3";
        this.btn3.Size = new System.Drawing.Size(30, 30);
        this.btn3.TabIndex = 0;
        this.btn3.UseVisualStyleBackColor = false;
        // 
        // Form1
        // 
        this.BackColor = System.Drawing.Color.LightGray;
        this.ClientSize = new System.Drawing.Size(684, 461);
        this.Controls.Add(this.pnl1);
        this.Controls.Add(this.pnl2);
        this.Controls.Add(this.pnl3);
        this.Name = "Form1";
        this.Text = "Bermuda Triangle Airways";
        this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
        this.pnl1.ResumeLayout(false);
        this.pnl3.ResumeLayout(false);
        this.ResumeLayout(false);

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
    int length_to_go;
    private int delay;
    private Panel panel;
    private int direction;
    private Color colour;
    private Point plane;
    private int xDelta;
    private int yDelta;
    private Semaphore semaphore;
    private Buffer buffer;
    private Button btn;
    private bool locked = true;



    public ButtonPanelThread(Point origin,
                             int length_to_go,
                             int delay,
                             int direction,
                             Panel panel,
                             Color colour,
                             Semaphore semaphore,
                             Buffer buffer,
                             Button btn)
    {
        this.origin = origin;
        this.length_to_go = length_to_go;
        this.delay = delay;
        this.direction = direction;
        this.panel = panel;
        this.colour = colour;
        this.plane = origin;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.xDelta = (direction == 1) ? +10 : ((direction == 2) ? -10 : 0);
        this.yDelta = (direction == 3) ? +10 : ((direction == 4) ? -10 : 0);
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


        while (true)
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
            for (int i = 1; i <= length_to_go; i++)
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

public class LinkPanelThread
{
    private Point origin;
    int length_to_go;
    private int delay;
    private Panel panel;
    private int direction;
    private Color colour;
    private Point plane;
    private int xDelta;
    private int yDelta;
    private Semaphore semaphore;
    private Buffer buffer;
    private Semaphore next_semaphore;
    private Buffer next_buffer;


    public LinkPanelThread(Point origin,
                       int length_to_go,
                       int delay,
                       int direction,
                       Panel panel,
                       Color colour,
                       Semaphore semaphore,
                       Buffer buffer,
                       Semaphore next_semaphore,
                       Buffer next_buffer)
    {
        this.origin = origin;
        this.length_to_go = length_to_go;
        this.delay = delay;
        this.direction = direction;
        this.panel = panel;
        this.colour = colour;
        this.plane = origin;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.xDelta = (direction == 1) ? +10 : ((direction == 2) ? -10 : 0);
        this.yDelta = (direction == 3) ? +10 : ((direction == 4) ? -10 : 0);
        this.semaphore = semaphore;
        this.buffer = buffer;
        this.next_semaphore = next_semaphore;
        this.next_buffer = next_buffer;

    }

    public void Start()
    {

        //Thread.Sleep(delay);
        this.colour = Color.White;
        while (true)
        {
            semaphore.Signal();
            this.zeroPlane();

            buffer.Read(ref this.colour);

            for (int i = 1; i <= length_to_go; i++)
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
}// end class LinkPanelThread

public class RunwayPanelThread
{
    private Point origin;
    int length_to_go;
    private int delay;
    private Panel panel;
    private int direction;
    private Color colour;
    private Point plane;
    private int xDelta;
    private int yDelta;
    private Semaphore semaphore;
    private Buffer buffer;


    public RunwayPanelThread(Point origin,
                       int length_to_go,
                       int delay,
                       int direction,
                       Panel panel,
                       Color colour,
                       Semaphore semaphore,
                       Buffer buffer)
    {
        this.origin = origin;
        this.length_to_go = length_to_go;
        this.delay = delay;
        this.direction = direction;
        this.panel = panel;
        this.colour = colour;
        this.plane = origin;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.xDelta = (direction == 1) ? +10 : ((direction == 2) ? -10 : 0);
        this.yDelta = (direction == 3) ? +10 : ((direction == 4) ? -10 : 0);
        this.semaphore = semaphore;
        this.buffer = buffer;

    }

    public void Start()
    {

        //Thread.Sleep(delay);
        this.colour = Color.White;
        while (true)
        {
            semaphore.Signal();
            this.zeroPlane();

            buffer.Read(ref this.colour);

            for (int i = 1; i <= length_to_go; i++)
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
}// end class RunwayPanelThread

public class TheOne
{
    public static void Main()//
    {

        Application.Run(new Form1());
    }
}// end class TheOne

