
using System;
using Gtk;

namespace TestBoxing
{
	class GtkUnBoxingSample : Window
	{
		Entry txtNumber1 = new Entry();
		Entry txtNumber2 = new Entry();
		Button btnOk = new Button("Ok");
		Label lblMsg = new Label(string.Empty);
		Label lblError = new Label(string.Empty);
		
		public GtkUnBoxingSample() : base("Unboxing sample")
		{
			DeleteEvent += new DeleteEventHandler(ClosedWindowEvent);
			btnOk.Clicked += new EventHandler(HandleBtnOkClicked);
			this.BorderWidth = 6;
			var f = new Frame("Enter two numbers");
			this.Add(f);
			var vbox = new VBox(false,8);
			Table t = new Table(3,2,false);
			t.Attach(new Label("First number "),0,1,0,1);
			t.Attach(txtNumber1,1,2,0,1);
			t.Attach(new Label("Second number"),0,1,1,2);
			t.Attach(txtNumber2,1,2,1,2);
			vbox.PackStart(t,false,false,0);
			HButtonBox bb = new HButtonBox();
			bb.Add(btnOk);
			vbox.Add(bb);
			vbox.Add(lblMsg);
			vbox.Add(lblError);
			f.Add(vbox);
			ShowAll();
		}
		
		void HandleBtnOkClicked (object sender, EventArgs e)
		{
			lblError.Text = string.Empty;
			try
			{
				double x,y,temp;
				x = Double.Parse (txtNumber1.Text);//Unboxing string to double
				y = Convert.ToDouble(txtNumber2.Text);//Unboxing 
				if(y > x)
				{
					temp = x;
					x = y;
					y = temp;
				}
				lblMsg.Text = x.ToString() + " greater than " + y.ToString();//Boxing
			}catch(FormatException ex){
				lblMsg.Text = string.Empty;
				lblError.Text = ex.Message;				
			}
		}
		
		void ClosedWindowEvent(object o, DeleteEventArgs args){
			Application.Quit();
			
		}
		public static void Main(string[] args)
		{
			Application.Init();
			new GtkUnBoxingSample();
			Application.Run();
		}
	}
}
