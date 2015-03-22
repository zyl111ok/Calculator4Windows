using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace ZYLCalculator
{
    public partial class CalculatorWindow : Form
    {
        private Label label;
        private String s;
        private Boolean clear = true;
        public CalculatorWindow()
        {
            
            this.Text = "ZYL_Calculator";
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            testResult.Text = "hello";
            buttonListener();
        }

        private void buttonListener()
        {
            btn0.Click+=new EventHandler(btnClick);
            btn1.Click += new EventHandler(btnClick);
            btn2.Click += new EventHandler(btnClick);
            btn3.Click += new EventHandler(btnClick);
            btn4.Click += new EventHandler(btnClick);
            btn5.Click += new EventHandler(btnClick);
            btn6.Click += new EventHandler(btnClick);
            btn7.Click += new EventHandler(btnClick);
            btn8.Click += new EventHandler(btnClick);
            btn9.Click += new EventHandler(btnClick);
            btnPoint.Click += new EventHandler(btnClick);
            btnMutiply.Click += new EventHandler(btnClick);
            btnDivide.Click += new EventHandler(btnClick);
            btnAdd.Click += new EventHandler(btnClick);
            btnPlus.Click += new EventHandler(btnClick);
            btnClear.Click += new EventHandler(btnClick);
            btnEquals.Click += new EventHandler(btnClick);
            btnLeft.Click += new EventHandler(btnClick);
            btnRight.Click += new EventHandler(btnClick);
        }

        void btnClick(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                case ".":
                case "+":
                case "-":
                case "*":
                case "/":
                case "(":
                case ")":
                    if (this.clear)
                    {
                        testResult.Text = btn.Text;
                        clear = false;
                    }
                    else
                    {
                        testResult.Text += btn.Text;
                    }
                    break;
                case "CE":
                    {
                        this.clear = true;
                        testResult.Text = "0";
                        break;
                    }
                case "=":
                    {
                        String temp = testResult.Text + "=";
                        ResultUtils ru = new ResultUtils(testResult.Text);
                        String tmp = ru.getResult();
                        if (tmp.Equals("error"))
                        {
                            testResult.Text = "表达式错误，请正确输入,按CE继续";
                        }
                        else
                        {
                            testResult.Text = temp + ru.getResult();
                        }
                        break;
                    }
            }
        }
      
    }
}
