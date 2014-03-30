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
    private Panel panel_button_blue1, panel_button_red1, panel_button_green1, panel_button_purple1;
    private Button button_blue1, button_red1, button_green1, button_purple1;
    private ButtonPanelThread button_panel_thread_panel_button_blue1, button_panel_thread_panel_button_red1, button_panel_thread_panel_button_green1, button_panel_thread_panel_button_purple1;
    private Panel panel_link1, panel_link2;
    private LinkPanelThread link_panel_thread_panel_link1, link_panel_thread_panel_link2;
    private Panel panel_runway1;
    private RunwayPanelThread runway_panel_thread_panel_runway1;
    private Thread thread1, thread2, thread3, thread4, thread5, thread6, thread7;
    private Semaphore semaphore1, semaphore2, semaphore3;
    private Buffer buffer1, buffer2, buffer3;
    private Thread semThread1, semThread2, semThread3;
    private Thread buffThread1, buffThread2, buffThread3;


    public Form1()
    {
        InitializeComponent();


        semaphore1 = new Semaphore();
        buffer1 = new Buffer();
        semaphore2 = new Semaphore();
        buffer2 = new Buffer();
        semaphore3 = new Semaphore();
        buffer3 = new Buffer();


        button_panel_thread_panel_button_blue1 = new ButtonPanelThread(new Point(10, 40),
                                7,
                             120, 3, panel_button_blue1,
                             Color.Blue,
                             semaphore1,
                             buffer1,
                             button_blue1);

        button_panel_thread_panel_button_red1 = new ButtonPanelThread(new Point(40, 10),
                        20,
                     250, 1, panel_button_red1,
                     Color.Red,
                     semaphore1,
                     buffer1,
                     button_red1);

        button_panel_thread_panel_button_green1 = new ButtonPanelThread(new Point(10, 40),
                        7,
                     120, 3, panel_button_green1,
                     Color.Green,
                     semaphore2,
                     buffer2,
                     button_green1);

        button_panel_thread_panel_button_purple1 = new ButtonPanelThread(new Point(10, 40),
                        7,
                     120, 3, panel_button_purple1,
                     Color.Purple,
                     semaphore3,
                     buffer3,
                     button_purple1);

        link_panel_thread_panel_link1 = new LinkPanelThread(new Point(8, 10),
                                17,
                             100, 1, panel_link1,
                             Color.White,
                             semaphore1,
                             buffer1,
                             semaphore2,
                             buffer2);

        link_panel_thread_panel_link2 = new LinkPanelThread(new Point(8, 10),
                        17,
                     100, 1, panel_link2,
                     Color.White,
                     semaphore2,
                     buffer2,
                     semaphore3,
                     buffer3);

        runway_panel_thread_panel_runway1 = new RunwayPanelThread(new Point(10, 10),
                                23,
                             100, 1, panel_runway1,
                             Color.White,
                             semaphore3,
                             buffer3);


        semThread1 = new Thread(new ThreadStart(semaphore1.Start));
        buffThread1 = new Thread(new ThreadStart(buffer1.Start));
        semThread2 = new Thread(new ThreadStart(semaphore2.Start));
        buffThread2 = new Thread(new ThreadStart(buffer2.Start));
        semThread3 = new Thread(new ThreadStart(semaphore3.Start));
        buffThread3 = new Thread(new ThreadStart(buffer3.Start));
        thread1 = new Thread(new ThreadStart(button_panel_thread_panel_button_blue1.Start));
        thread2 = new Thread(new ThreadStart(runway_panel_thread_panel_runway1.Start));
        thread3 = new Thread(new ThreadStart(button_panel_thread_panel_button_red1.Start));
        thread4 = new Thread(new ThreadStart(link_panel_thread_panel_link1.Start));
        thread5 = new Thread(new ThreadStart(link_panel_thread_panel_link2.Start));
        thread6 = new Thread(new ThreadStart(button_panel_thread_panel_button_green1.Start));
        thread7 = new Thread(new ThreadStart(button_panel_thread_panel_button_purple1.Start));


        this.Closing += new CancelEventHandler(this.Form1_Closing);

        semThread1.Start();
        buffThread1.Start();
        semThread2.Start();
        buffThread2.Start();
        semThread3.Start();
        buffThread3.Start();
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();
        thread6.Start();
        thread7.Start();

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
            this.panel_button_blue1 = new System.Windows.Forms.Panel();
            this.button_blue1 = new System.Windows.Forms.Button();
            this.panel_runway1 = new System.Windows.Forms.Panel();
            this.panel_button_red1 = new System.Windows.Forms.Panel();
            this.button_red1 = new System.Windows.Forms.Button();
            this.panel_link1 = new System.Windows.Forms.Panel();
            this.panel_link2 = new System.Windows.Forms.Panel();
            this.panel_button_green1 = new System.Windows.Forms.Panel();
            this.button_green1 = new System.Windows.Forms.Button();
            this.panel_button_purple1 = new System.Windows.Forms.Panel();
            this.button_purple1 = new System.Windows.Forms.Button();
            this.panel_button_blue1.SuspendLayout();
            this.panel_button_red1.SuspendLayout();
            this.panel_button_green1.SuspendLayout();
            this.panel_button_purple1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_button_blue1
            // 
            this.panel_button_blue1.BackColor = System.Drawing.Color.White;
            this.panel_button_blue1.Controls.Add(this.button_blue1);
            this.panel_button_blue1.Location = new System.Drawing.Point(370, 68);
            this.panel_button_blue1.Name = "panel_button_blue1";
            this.panel_button_blue1.Size = new System.Drawing.Size(30, 126);
            this.panel_button_blue1.TabIndex = 0;
            // 
            // button_blue1
            // 
            this.button_blue1.BackColor = System.Drawing.Color.Pink;
            this.button_blue1.Location = new System.Drawing.Point(0, 0);
            this.button_blue1.Name = "button_blue1";
            this.button_blue1.Size = new System.Drawing.Size(30, 30);
            this.button_blue1.TabIndex = 0;
            this.button_blue1.UseVisualStyleBackColor = false;
            // 
            // panel_runway1
            // 
            this.panel_runway1.BackColor = System.Drawing.Color.White;
            this.panel_runway1.Location = new System.Drawing.Point(782, 200);
            this.panel_runway1.Name = "panel_runway1";
            this.panel_runway1.Size = new System.Drawing.Size(260, 30);
            this.panel_runway1.TabIndex = 1;
            // 
            // panel_button_red1
            // 
            this.panel_button_red1.BackColor = System.Drawing.Color.White;
            this.panel_button_red1.Controls.Add(this.button_red1);
            this.panel_button_red1.Location = new System.Drawing.Point(104, 200);
            this.panel_button_red1.Name = "panel_button_red1";
            this.panel_button_red1.Size = new System.Drawing.Size(260, 30);
            this.panel_button_red1.TabIndex = 2;
            // 
            // button_red1
            // 
            this.button_red1.BackColor = System.Drawing.Color.Pink;
            this.button_red1.Location = new System.Drawing.Point(0, 0);
            this.button_red1.Name = "button_red1";
            this.button_red1.Size = new System.Drawing.Size(30, 30);
            this.button_red1.TabIndex = 0;
            this.button_red1.UseVisualStyleBackColor = false;
            // 
            // panel_link1
            // 
            this.panel_link1.BackColor = System.Drawing.Color.White;
            this.panel_link1.Location = new System.Drawing.Point(370, 200);
            this.panel_link1.Name = "panel_link1";
            this.panel_link1.Size = new System.Drawing.Size(200, 30);
            this.panel_link1.TabIndex = 3;
            // 
            // panel_link2
            // 
            this.panel_link2.BackColor = System.Drawing.Color.White;
            this.panel_link2.Location = new System.Drawing.Point(576, 200);
            this.panel_link2.Name = "panel_link2";
            this.panel_link2.Size = new System.Drawing.Size(200, 30);
            this.panel_link2.TabIndex = 4;
            // 
            // panel_button_green1
            // 
            this.panel_button_green1.BackColor = System.Drawing.Color.White;
            this.panel_button_green1.Controls.Add(this.button_green1);
            this.panel_button_green1.Location = new System.Drawing.Point(576, 68);
            this.panel_button_green1.Name = "panel_button_green1";
            this.panel_button_green1.Size = new System.Drawing.Size(30, 126);
            this.panel_button_green1.TabIndex = 1;
            // 
            // button_green1
            // 
            this.button_green1.BackColor = System.Drawing.Color.Pink;
            this.button_green1.Location = new System.Drawing.Point(0, 0);
            this.button_green1.Name = "button_green1";
            this.button_green1.Size = new System.Drawing.Size(30, 30);
            this.button_green1.TabIndex = 0;
            this.button_green1.UseVisualStyleBackColor = false;
            // 
            // panel_button_purple1
            // 
            this.panel_button_purple1.BackColor = System.Drawing.Color.White;
            this.panel_button_purple1.Controls.Add(this.button_purple1);
            this.panel_button_purple1.Location = new System.Drawing.Point(782, 68);
            this.panel_button_purple1.Name = "panel_button_purple1";
            this.panel_button_purple1.Size = new System.Drawing.Size(30, 126);
            this.panel_button_purple1.TabIndex = 2;
            // 
            // button_purple1
            // 
            this.button_purple1.BackColor = System.Drawing.Color.Pink;
            this.button_purple1.Location = new System.Drawing.Point(0, 0);
            this.button_purple1.Name = "button_purple1";
            this.button_purple1.Size = new System.Drawing.Size(30, 30);
            this.button_purple1.TabIndex = 0;
            this.button_purple1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1246, 585);
            this.Controls.Add(this.panel_button_purple1);
            this.Controls.Add(this.panel_button_green1);
            this.Controls.Add(this.panel_link2);
            this.Controls.Add(this.panel_link1);
            this.Controls.Add(this.panel_button_blue1);
            this.Controls.Add(this.panel_runway1);
            this.Controls.Add(this.panel_button_red1);
            this.Name = "Form1";
            this.Text = "Bermuda Triangle Airways";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panel_button_blue1.ResumeLayout(false);
            this.panel_button_red1.ResumeLayout(false);
            this.panel_button_green1.ResumeLayout(false);
            this.panel_button_purple1.ResumeLayout(false);
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
            /* les lignes qui changent tout */
            next_semaphore.Wait();
            next_buffer.Write(this.colour);
            /*------------------------------*/
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

