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
    private Panel panel_button_blue1, panel_button_red1, panel_button_green1, panel_button_purple1, panel_button_yellow1, panel_button_orange1;
    private Button button_blue1, button_red1, button_green1, button_purple1, button_yellow1, button_orange1;
    private ButtonPanelThread button_panel_thread_panel_button_blue1, button_panel_thread_panel_button_red1, button_panel_thread_panel_button_green1, button_panel_thread_panel_button_purple1, button_panel_thread_panel_button_yellow1, button_panel_thread_panel_button_orange1;
    private Panel panel_link1, panel_link2, panel_link3, panel_link4, panel_link5;
    private LinkPanelThread link_panel_thread_panel_link1, link_panel_thread_panel_link2, link_panel_thread_panel_link3, link_panel_thread_panel_link4, link_panel_thread_panel_link5;
    private Panel panel_runway1;
    private RunwayPanelThread runway_panel_thread_panel_runway1;
    private Panel panel_crossing_type1;
    private CrossingType1PanelThread crossing_type1_panel_thread_panel_crossing_type1;
    private Panel panel_crossing_type2;
    private CrossingType2PanelThread crossing_type2_panel_thread_panel_crossing_type2;
    private Panel panel_garage1, panel_garage2;
    private GaragePanelThread garage_panel_thread_panel_garage1, garage_panel_thread_panel_garage2;
    private Thread thread1, thread2, thread3, thread4, thread5, thread6, thread7, thread8, thread9, thread10, thread11, thread12, thread13, thread14, thread15, thread16;
    private Semaphore semaphore1, semaphore2, semaphore3, semaphore4, semaphore5, semaphore6, semaphore7, semaphore8, semaphore9, semaphore10;
    private Buffer buffer1, buffer2, buffer3, buffer4, buffer5, buffer6, buffer7, buffer8, buffer9, buffer10;
    private Thread semThread1, semThread2, semThread3, semThread4, semThread5, semThread6, semThread7, semThread8, semThread9, semThread10;
    private Thread buffThread1, buffThread2, buffThread3, buffThread4, buffThread5, buffThread6, buffThread7, buffThread8, buffThread9, buffThread10;
    private RadioButton radio_button_garage1, radio_button_garage2;


    public Form1()
    {
        InitializeComponent();


        semaphore1 = new Semaphore();
        buffer1 = new Buffer();
        semaphore2 = new Semaphore();
        buffer2 = new Buffer();
        semaphore3 = new Semaphore();
        buffer3 = new Buffer();
        semaphore4 = new Semaphore();
        buffer4 = new Buffer();
        semaphore5 = new Semaphore();
        buffer5 = new Buffer();
        semaphore6 = new Semaphore();
        buffer6 = new Buffer();
        semaphore7 = new Semaphore();
        buffer7 = new Buffer();
        semaphore8 = new Semaphore();
        buffer8 = new Buffer();
        semaphore9 = new Semaphore();
        buffer9 = new Buffer();
        semaphore10 = new Semaphore();
        buffer10 = new Buffer();


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

        button_panel_thread_panel_button_yellow1 = new ButtonPanelThread(new Point(10, 40),
                        7,
                     120, 3, panel_button_yellow1,
                     Color.Yellow,
                     semaphore4,
                     buffer4,
                     button_yellow1);

        button_panel_thread_panel_button_orange1 = new ButtonPanelThread(new Point(145, 10),
                        13,
                     120, 2, panel_button_orange1,
                     Color.Orange,
                     semaphore5,
                     buffer5,
                     button_orange1);

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

        link_panel_thread_panel_link3 = new LinkPanelThread(new Point(8, 10),
                        17,
                     100, 1, panel_link3,
                     Color.White,
                     semaphore3,
                     buffer3,
                     semaphore4,
                     buffer4);

        link_panel_thread_panel_link4 = new LinkPanelThread(new Point(10, 8),
                        28,
                     100, 3, panel_link4,
                     Color.White,
                     semaphore4,
                     buffer4,
                     semaphore5,
                     buffer5);

        link_panel_thread_panel_link5 = new LinkPanelThread(new Point(10, 100),
                        9,
                     100, 4, panel_link5,
                     Color.White,
                     semaphore8,
                     buffer8,
                     semaphore10,
                     buffer10);

        crossing_type1_panel_thread_panel_crossing_type1 = new CrossingType1PanelThread(new Point(640, 10),
                        63,
                     100, 2, panel_crossing_type1,
                     Color.White,
                     semaphore5,
                     buffer5,
                     semaphore6,
                     buffer6,
                     semaphore7,
                     buffer7);

        crossing_type2_panel_thread_panel_crossing_type2 = new CrossingType2PanelThread(new Point(10, 100),
                        9,
                     100, 4, panel_crossing_type2,
                     Color.White,
                     semaphore7,
                     buffer7,
                     radio_button_garage1,
                     semaphore8,
                     buffer8,
                     semaphore9,
                     buffer9);

        garage_panel_thread_panel_garage1 = new GaragePanelThread(new Point(8, 10),
                                11,
                             100, 1, panel_garage1,
                             Color.White,
                             semaphore9,
                             buffer9);

        garage_panel_thread_panel_garage2 = new GaragePanelThread(new Point(8, 10),
                                11,
                             100, 1, panel_garage2,
                             Color.White,
                             semaphore10,
                             buffer10);

        runway_panel_thread_panel_runway1 = new RunwayPanelThread(new Point(323, 10),
                                31,
                             100, 2, panel_runway1,
                             Color.White,
                             semaphore6,
                             buffer6);


        semThread1 = new Thread(new ThreadStart(semaphore1.Start));
        buffThread1 = new Thread(new ThreadStart(buffer1.Start));
        semThread2 = new Thread(new ThreadStart(semaphore2.Start));
        buffThread2 = new Thread(new ThreadStart(buffer2.Start));
        semThread3 = new Thread(new ThreadStart(semaphore3.Start));
        buffThread3 = new Thread(new ThreadStart(buffer3.Start));
        semThread4 = new Thread(new ThreadStart(semaphore4.Start));
        buffThread4 = new Thread(new ThreadStart(buffer4.Start));
        semThread5 = new Thread(new ThreadStart(semaphore5.Start));
        buffThread5 = new Thread(new ThreadStart(buffer5.Start));
        semThread6 = new Thread(new ThreadStart(semaphore6.Start));
        buffThread6 = new Thread(new ThreadStart(buffer6.Start));
        semThread7 = new Thread(new ThreadStart(semaphore7.Start));
        buffThread7 = new Thread(new ThreadStart(buffer7.Start));
        semThread8 = new Thread(new ThreadStart(semaphore8.Start));
        buffThread8 = new Thread(new ThreadStart(buffer8.Start));
        semThread9 = new Thread(new ThreadStart(semaphore9.Start));
        buffThread9 = new Thread(new ThreadStart(buffer9.Start));
        semThread10 = new Thread(new ThreadStart(semaphore10.Start));
        buffThread10 = new Thread(new ThreadStart(buffer10.Start));
        thread1 = new Thread(new ThreadStart(button_panel_thread_panel_button_blue1.Start));
        thread2 = new Thread(new ThreadStart(runway_panel_thread_panel_runway1.Start));
        thread3 = new Thread(new ThreadStart(button_panel_thread_panel_button_red1.Start));
        thread4 = new Thread(new ThreadStart(link_panel_thread_panel_link1.Start));
        thread5 = new Thread(new ThreadStart(link_panel_thread_panel_link2.Start));
        thread6 = new Thread(new ThreadStart(button_panel_thread_panel_button_green1.Start));
        thread7 = new Thread(new ThreadStart(button_panel_thread_panel_button_purple1.Start));
        thread8 = new Thread(new ThreadStart(link_panel_thread_panel_link3.Start));
        thread9 = new Thread(new ThreadStart(link_panel_thread_panel_link4.Start));
        thread10 = new Thread(new ThreadStart(crossing_type1_panel_thread_panel_crossing_type1.Start));
        thread11 = new Thread(new ThreadStart(crossing_type2_panel_thread_panel_crossing_type2.Start));
        thread12 = new Thread(new ThreadStart(link_panel_thread_panel_link5.Start));
        thread13 = new Thread(new ThreadStart(garage_panel_thread_panel_garage1.Start));
        thread14 = new Thread(new ThreadStart(garage_panel_thread_panel_garage2.Start));
        thread15 = new Thread(new ThreadStart(button_panel_thread_panel_button_yellow1.Start));
        thread16 = new Thread(new ThreadStart(button_panel_thread_panel_button_orange1.Start));


        this.Closing += new CancelEventHandler(this.Form1_Closing);

        semThread1.Start();
        buffThread1.Start();
        semThread2.Start();
        buffThread2.Start();
        semThread3.Start();
        buffThread3.Start();
        semThread4.Start();
        buffThread4.Start();
        semThread5.Start();
        buffThread5.Start();
        semThread6.Start();
        buffThread6.Start();
        semThread7.Start();
        buffThread7.Start();
        semThread8.Start();
        buffThread8.Start();
        semThread9.Start();
        buffThread9.Start();
        semThread10.Start();
        buffThread10.Start();
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();
        thread6.Start();
        thread7.Start();
        thread8.Start();
        thread9.Start();
        thread10.Start();
        thread11.Start();
        thread12.Start();
        thread13.Start();
        thread14.Start();
        thread15.Start();
        thread16.Start();

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
            this.panel_link3 = new System.Windows.Forms.Panel();
            this.panel_link4 = new System.Windows.Forms.Panel();
            this.panel_crossing_type2 = new System.Windows.Forms.Panel();
            this.panel_crossing_type1 = new System.Windows.Forms.Panel();
            this.panel_link5 = new System.Windows.Forms.Panel();
            this.panel_garage1 = new System.Windows.Forms.Panel();
            this.panel_garage2 = new System.Windows.Forms.Panel();
            this.panel_button_yellow1 = new System.Windows.Forms.Panel();
            this.button_yellow1 = new System.Windows.Forms.Button();
            this.panel_button_orange1 = new System.Windows.Forms.Panel();
            this.button_orange1 = new System.Windows.Forms.Button();
            this.radio_button_garage1 = new System.Windows.Forms.RadioButton();
            this.radio_button_garage2 = new System.Windows.Forms.RadioButton();
            this.panel_button_blue1.SuspendLayout();
            this.panel_button_red1.SuspendLayout();
            this.panel_button_green1.SuspendLayout();
            this.panel_button_purple1.SuspendLayout();
            this.panel_button_yellow1.SuspendLayout();
            this.panel_button_orange1.SuspendLayout();
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
            this.panel_runway1.Location = new System.Drawing.Point(28, 519);
            this.panel_runway1.Name = "panel_runway1";
            this.panel_runway1.Size = new System.Drawing.Size(336, 30);
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
            // panel_link3
            // 
            this.panel_link3.BackColor = System.Drawing.Color.White;
            this.panel_link3.Location = new System.Drawing.Point(782, 201);
            this.panel_link3.Name = "panel_link3";
            this.panel_link3.Size = new System.Drawing.Size(200, 29);
            this.panel_link3.TabIndex = 5;
            // 
            // panel_link4
            // 
            this.panel_link4.BackColor = System.Drawing.Color.White;
            this.panel_link4.Location = new System.Drawing.Point(988, 201);
            this.panel_link4.Name = "panel_link4";
            this.panel_link4.Size = new System.Drawing.Size(30, 312);
            this.panel_link4.TabIndex = 6;
            // 
            // panel_crossing_type2
            // 
            this.panel_crossing_type2.BackColor = System.Drawing.Color.White;
            this.panel_crossing_type2.Location = new System.Drawing.Point(370, 405);
            this.panel_crossing_type2.Name = "panel_crossing_type2";
            this.panel_crossing_type2.Size = new System.Drawing.Size(30, 108);
            this.panel_crossing_type2.TabIndex = 7;
            // 
            // panel_crossing_type1
            // 
            this.panel_crossing_type1.BackColor = System.Drawing.Color.White;
            this.panel_crossing_type1.Location = new System.Drawing.Point(370, 519);
            this.panel_crossing_type1.Name = "panel_crossing_type1";
            this.panel_crossing_type1.Size = new System.Drawing.Size(648, 29);
            this.panel_crossing_type1.TabIndex = 8;
            // 
            // panel_link5
            // 
            this.panel_link5.BackColor = System.Drawing.Color.White;
            this.panel_link5.Location = new System.Drawing.Point(370, 293);
            this.panel_link5.Name = "panel_link5";
            this.panel_link5.Size = new System.Drawing.Size(30, 105);
            this.panel_link5.TabIndex = 9;
            // 
            // panel_garage1
            // 
            this.panel_garage1.BackColor = System.Drawing.Color.White;
            this.panel_garage1.Location = new System.Drawing.Point(406, 405);
            this.panel_garage1.Name = "panel_garage1";
            this.panel_garage1.Size = new System.Drawing.Size(136, 32);
            this.panel_garage1.TabIndex = 10;
            // 
            // panel_garage2
            // 
            this.panel_garage2.BackColor = System.Drawing.Color.White;
            this.panel_garage2.Location = new System.Drawing.Point(406, 293);
            this.panel_garage2.Name = "panel_garage2";
            this.panel_garage2.Size = new System.Drawing.Size(136, 32);
            this.panel_garage2.TabIndex = 11;
            // 
            // panel_button_yellow1
            // 
            this.panel_button_yellow1.BackColor = System.Drawing.Color.White;
            this.panel_button_yellow1.Controls.Add(this.button_yellow1);
            this.panel_button_yellow1.Location = new System.Drawing.Point(988, 68);
            this.panel_button_yellow1.Name = "panel_button_yellow1";
            this.panel_button_yellow1.Size = new System.Drawing.Size(30, 126);
            this.panel_button_yellow1.TabIndex = 3;
            // 
            // button_yellow1
            // 
            this.button_yellow1.BackColor = System.Drawing.Color.Pink;
            this.button_yellow1.Location = new System.Drawing.Point(0, 0);
            this.button_yellow1.Name = "button_yellow1";
            this.button_yellow1.Size = new System.Drawing.Size(30, 30);
            this.button_yellow1.TabIndex = 0;
            this.button_yellow1.UseVisualStyleBackColor = false;
            // 
            // panel_button_orange1
            // 
            this.panel_button_orange1.BackColor = System.Drawing.Color.White;
            this.panel_button_orange1.Controls.Add(this.button_orange1);
            this.panel_button_orange1.Location = new System.Drawing.Point(1024, 519);
            this.panel_button_orange1.Name = "panel_button_orange1";
            this.panel_button_orange1.Size = new System.Drawing.Size(191, 29);
            this.panel_button_orange1.TabIndex = 4;
            // 
            // button_orange1
            // 
            this.button_orange1.BackColor = System.Drawing.Color.Pink;
            this.button_orange1.Location = new System.Drawing.Point(161, 0);
            this.button_orange1.Name = "button_orange1";
            this.button_orange1.Size = new System.Drawing.Size(30, 30);
            this.button_orange1.TabIndex = 0;
            this.button_orange1.UseVisualStyleBackColor = false;
            // 
            // radio_button_garage1
            // 
            this.radio_button_garage1.AutoSize = true;
            this.radio_button_garage1.Checked = true;
            this.radio_button_garage1.Location = new System.Drawing.Point(592, 308);
            this.radio_button_garage1.Name = "radio_button_garage1";
            this.radio_button_garage1.Size = new System.Drawing.Size(64, 17);
            this.radio_button_garage1.TabIndex = 12;
            this.radio_button_garage1.TabStop = true;
            this.radio_button_garage1.Text = "garage1";
            this.radio_button_garage1.UseVisualStyleBackColor = true;
            // 
            // radio_button_garage2
            // 
            this.radio_button_garage2.AutoSize = true;
            this.radio_button_garage2.Location = new System.Drawing.Point(592, 420);
            this.radio_button_garage2.Name = "radio_button_garage2";
            this.radio_button_garage2.Size = new System.Drawing.Size(64, 17);
            this.radio_button_garage2.TabIndex = 13;
            this.radio_button_garage2.TabStop = true;
            this.radio_button_garage2.Text = "garage2";
            this.radio_button_garage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1246, 585);
            this.Controls.Add(this.radio_button_garage2);
            this.Controls.Add(this.radio_button_garage1);
            this.Controls.Add(this.panel_button_orange1);
            this.Controls.Add(this.panel_button_yellow1);
            this.Controls.Add(this.panel_garage2);
            this.Controls.Add(this.panel_garage1);
            this.Controls.Add(this.panel_link5);
            this.Controls.Add(this.panel_crossing_type1);
            this.Controls.Add(this.panel_crossing_type2);
            this.Controls.Add(this.panel_link4);
            this.Controls.Add(this.panel_link3);
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
            this.panel_button_yellow1.ResumeLayout(false);
            this.panel_button_orange1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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

public class CrossingType1PanelThread
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
    private Semaphore next_semaphore1;
    private Buffer next_buffer1;
    private Semaphore next_semaphore2;
    private Buffer next_buffer2;


    public CrossingType1PanelThread(Point origin,
                       int length_to_go,
                       int delay,
                       int direction,
                       Panel panel,
                       Color colour,
                       Semaphore semaphore,
                       Buffer buffer,
                       Semaphore next_semaphore1,
                       Buffer next_buffer1,
                        Semaphore next_semaphore2,
                       Buffer next_buffer2)
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
        this.next_semaphore1 = next_semaphore1;
        this.next_buffer1 = next_buffer1;
        this.next_semaphore2 = next_semaphore2;
        this.next_buffer2 = next_buffer2;

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
            if (!(this.colour == Color.Orange))
            {
                next_semaphore1.Wait();
                next_buffer1.Write(this.colour);
            }
            else
            {
                next_semaphore2.Wait();
                next_buffer2.Write(this.colour);
            }
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
}// end class CrossingType1PanelThread

public class CrossingType2PanelThread
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
    private RadioButton what_road;
    private Semaphore next_semaphore1;
    private Buffer next_buffer1;
    private Semaphore next_semaphore2;
    private Buffer next_buffer2;


    public CrossingType2PanelThread(Point origin,
                       int length_to_go,
                       int delay,
                       int direction,
                       Panel panel,
                       Color colour,
                       Semaphore semaphore,
                       Buffer buffer,
                       RadioButton what_road,
                       Semaphore next_semaphore1,
                       Buffer next_buffer1,
                        Semaphore next_semaphore2,
                       Buffer next_buffer2)
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
        this.what_road = what_road;
        this.next_semaphore1 = next_semaphore1;
        this.next_buffer1 = next_buffer1;
        this.next_semaphore2 = next_semaphore2;
        this.next_buffer2 = next_buffer2;

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
            if (what_road.Checked)
            {
                next_semaphore1.Wait();
                next_buffer1.Write(this.colour);
            }
            else
            {
                next_semaphore2.Wait();
                next_buffer2.Write(this.colour);
            }
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
}// end class CrossingType2PanelThread

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

public class GaragePanelThread
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


    public GaragePanelThread(Point origin,
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
}// end class GaragePanelThread

public class TheOne
{
    public static void Main()//
    {

        Application.Run(new Form1());
    }
}// end class TheOne

