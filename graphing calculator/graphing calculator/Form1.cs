using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Linq;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Policy;
using OxyPlot.Axes;

namespace graphing_calculator
{
    public partial class Form1 : Form
    {
        conversion[] constants = { new conversion("i", 0, 1), new conversion("e", MathF.E, 0), new conversion("p", MathF.PI, 0) };
        conversion[]? variables = default;
        parameter[] parameters = { new parameter("a", -1, 1), new parameter("b", -5, 5) };
        float accepetable_error;
        float freq;
        List<string> conditions = new List<string>();

        List<ScatterPoint> points = new List<ScatterPoint>();

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("|a+bi-i|=|a+bi|+1");
        }

        //call calculate
        private async void button4_Click(object sender, EventArgs e)
        {
            points = new List<ScatterPoint>();
            //check min max valid
            if (!(float.TryParse(textBox2.Text, out parameters[0].min) && float.TryParse(textBox3.Text, out parameters[0].max) && float.TryParse(textBox4.Text, out parameters[1].min) && float.TryParse(textBox5.Text, out parameters[1].max))) { label7.Text = "Check min max valid"; return; }
            //check appro. freq. valid
            if (!(float.TryParse(textBox6.Text, out freq) && freq <= 1f && freq >= 0.01f)) { label7.Text = "Check appro. freq. is in range 0.01-1"; return; }
            //check accep. err. valid
            if (float.TryParse(textBox7.Text, out accepetable_error) && accepetable_error <= 1f && accepetable_error >= 0f) { accepetable_error = MathF.Pow(accepetable_error, 4) * freq; }
            else { label7.Text = "Check accep. err. is in range 0-1"; return; }
            //check conditions valid
            conditions = new List<string>();
            foreach (string item in listBox1.Items)
            {
                conditions.Add(item);
            }
            await Process();
            label7.Text = "";
            var model = new PlotModel();

            // Add the line series to the plot view control's model
            ScatterSeries scatterSeries = new ScatterSeries();
            scatterSeries.ItemsSource = points;
            model.Series.Add(scatterSeries);

            // Add boundaries
            scatterSeries = new ScatterSeries();
            scatterSeries.MarkerFill = OxyColors.Red;
            scatterSeries.Points.Add(new ScatterPoint(parameters[0].min, parameters[1].min));
            scatterSeries.Points.Add(new ScatterPoint(parameters[0].max, parameters[1].min));
            scatterSeries.Points.Add(new ScatterPoint(parameters[0].min, parameters[1].max));
            scatterSeries.Points.Add(new ScatterPoint(parameters[0].max, parameters[1].max));
            model.Series.Add(scatterSeries);


            // Set the x-axis and y-axis to be the same
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                AxislineStyle = LineStyle.Solid,
                Title = "Real",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IsAxisVisible = true,
                Maximum = Math.Max(parameters[0].max, parameters[1].max),
                Minimum = Math.Min(parameters[0].min, parameters[1].min),
            };

            model.Axes.Add(xAxis);

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                AxislineStyle = LineStyle.Solid,
                Title = "Imag",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IsAxisVisible = true,
                Maximum = Math.Max(parameters[0].max, parameters[1].max),
                Minimum = Math.Min(parameters[0].min, parameters[1].min),
            };
            model.Axes.Add(yAxis);


            // Redraw the plot
            plotView1.Model = model;
            plotView1.InvalidatePlot(true);

        }

        //add condition
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        //clear conditions
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        //remove selected
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) { return; }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        #region checkConditionHelperFunction
        public bool Check(string s)
        {
            // () log trigo ^ || * / + -
            string[] parts = new string[2];
            parts = s.Split(new char[] { '=', '>', '<' }, StringSplitOptions.RemoveEmptyEntries);
            num lhs = eval(parts[0]);
            num rhs = eval(parts[1]);
            //Debug.Log(lhs);
            if (s.IndexOf(">=") != -1)
            {
                return (lhs.real + accepetable_error >= rhs.real);
            }
            if (s.IndexOf("<=") != -1)
            {
                return (lhs.real <= rhs.real + accepetable_error);
            }
            if (s.IndexOf("=") != -1)
            {
                return (Math.Abs(lhs.real - rhs.real) < accepetable_error && Math.Abs(lhs.imag - rhs.imag) < accepetable_error);
            }
            if (s.IndexOf(">") != -1)
            {
                return (lhs.real + accepetable_error > rhs.real);
            }
            if (s.IndexOf("<") != -1)
            {
                return (lhs.real < rhs.real + accepetable_error);
            }
            return false;
        }
        public num eval(string s)
        {
            //Debug.Log(s);
            float res;
            if (s[0] == '(' && s[s.Length - 1] == ')')
            {
                int count = 0;
                bool outside = true;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == '(' && count == -1)
                    {
                        outside = false;
                    }
                    if (s[i] == '(')
                    {
                        count++;
                    }
                    if (s[i] == ')')
                    {
                        count--;
                    }
                }
                if (outside)
                {
                    return eval(s.Substring(1, s.Length - 2));
                }
            }
            if (s[0] == '|' && s[s.Length - 1] == '|')
            {
                int count = 0;
                bool outside = true;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == '|' && count == -1)
                    {
                        outside = false;
                    }
                    if (s[i] == '|')
                    {
                        count++;
                    }
                    if (s[i] == '|')
                    {
                        count--;
                    }
                }
                if (outside)
                {
                    return compute("||", eval(s.Substring(1, s.Length - 2)));
                }
            }
            if (s.IndexOfAny(new char[] { 'e' }) == -1 && float.TryParse(s, out res))
            {
                return new num { real = res, imag = 0 };
            }
            foreach (conversion item in constants)
            {
                if (s == item.variable)
                {
                    return item.value;
                }
            }
            foreach (conversion item in variables)
            {
                if (s == item.variable)
                {
                    return item.value;
                }
            }
            if (LastIndex(s, "+") != -1)
            {
                string[] split = new string[2];
                split[0] = s.Substring(0, s.LastIndexOf("+"));
                split[1] = s.Substring(s.LastIndexOf("+") + 1);
                return compute("+", eval(split[0]), eval(split[1]));
            }
            if (LastIndex(s, "-") > 0 && !"+-*/(".Contains(s[s.LastIndexOf("-") - 1]))
            {
                string[] split = new string[2];
                split[0] = s.Substring(0, s.LastIndexOf("-"));
                split[1] = s.Substring(s.LastIndexOf("-") + 1);
                return compute("-", eval(split[0]), eval(split[1]));
            }
            if (LastIndex(s, "*") != -1)
            {
                string[] split = new string[2];
                split[0] = s.Substring(0, s.LastIndexOf("*"));
                split[1] = s.Substring(s.LastIndexOf("*") + 1);
                return compute("*", eval(split[0]), eval(split[1]));
            }
            if (LastIndex(s, "/") != -1)
            {
                string[] split = new string[2];
                split[0] = s.Substring(0, s.LastIndexOf("/"));
                split[1] = s.Substring(s.LastIndexOf("/") + 1);
                return compute("/", eval(split[0]), eval(split[1]));
            }
            if (LastIndex(s, "^") != -1)
            {
                string[] split = new string[2];
                split[0] = s.Substring(0, s.LastIndexOf("^"));
                split[1] = s.Substring(s.LastIndexOf("^") + 1);
                return compute("^", eval(split[0]), eval(split[1]));
            }
            string[] ops = { "IMAG", "REAL", "Arg", "ln", "sin", "cos", "tan", "sqrt", "asin", "acos", "atan" };
            foreach (conversion item in variables)//rightmost is variable
            {
                if (s.EndsWith(item.variable) && !ops.Any(op => s.Substring(0, s.Length - item.variable.Length).EndsWith(op)))
                {
                    //Debug.Log("0"+s.Substring(s.Length-item.variable.Length));
                    return compute("*", eval(s.Substring(0, s.Length - item.variable.Length)), item.value);
                }
            }
            foreach (conversion item in constants)//rightmost is constant
            {
                if (s.EndsWith(item.variable) && !ops.Any(op => s.Substring(0, s.Length - item.variable.Length).EndsWith(op)))
                {
                    //Debug.Log("0"+s.Substring(s.Length-item.variable.Length));
                    return compute("*", eval(s.Substring(0, s.Length - item.variable.Length)), item.value);
                }
            }
            if (float.TryParse(s[s.Length - 1].ToString(), out res))//rightmost is float
            {
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] != '.' && !float.TryParse(s.Substring(i), out res) && !ops.Any(op => s.Substring(i + 1).EndsWith(op)))
                    {
                        return compute("*", eval(s.Substring(0, i)), eval(s.Substring(i)));
                    }
                }
            }
            foreach (string op in ops)
            {
                if (LastIndex(s, op) != -1)
                {
                    if (s.LastIndexOf(op) == 0)
                    {
                        //Debug.Log("1");
                        return compute(op, eval(s.Substring(s.LastIndexOf(op) + op.Length)));
                    }
                    //Debug.Log("2");
                    return compute("*", eval(s.Substring(0, s.LastIndexOf(op))), compute(op, eval(s.Substring(s.LastIndexOf(op) + op.Length))));
                }
            }
            return new num { real = float.PositiveInfinity, imag = float.PositiveInfinity };
        }
        private num compute(string op, num operand0, num operand1 = new num())
        {
            //Debug.Log(op + "|" + operand0 + "|" + operand1);
            num result = new num();
            result.real = 0;
            result.imag = 0;
            switch (op)
            {
                case "+":
                    result.real = operand0.real + operand1.real;
                    result.imag = operand0.imag + operand1.imag;
                    break;
                case "-":
                    result.real = operand0.real - operand1.real;
                    result.imag = operand0.imag - operand1.imag;
                    break;
                case "*":
                    result.real = operand0.real * operand1.real - operand0.imag * operand1.imag;
                    result.imag = operand0.real * operand1.imag + operand0.imag * operand1.real;
                    break;
                case "/":
                    result.real = (operand0.real * operand1.real + operand0.imag * operand1.imag) / (operand1.real * operand1.real + operand1.imag * operand1.imag);
                    result.imag = (operand0.imag * operand1.real - operand0.real * operand1.imag) / (operand1.real * operand1.real + operand1.imag * operand1.imag);
                    break;
                case "^":
                    float theta = MathF.Atan(operand0.imag / operand0.real);
                    if (theta < 0) { theta += MathF.PI; }
                    float r = MathF.Sqrt(operand0.real * operand0.real + operand0.imag * operand0.imag);
                    result.real = MathF.Pow(r, operand1.real) * MathF.Cos(operand1.real * theta);
                    result.imag = MathF.Pow(r, operand1.real) * MathF.Sin(operand1.real * theta);
                    break;
                case "ln":
                    result.real = MathF.Log(operand0.real, operand1.real);
                    break;
                case "sin":
                    result.real = MathF.Sin(operand0.real);
                    break;
                case "cos":
                    result.real = MathF.Cos(operand0.real);
                    break;
                case "tan":
                    result.real = MathF.Tan(operand0.real);
                    break;
                case "asin":
                    result.real = MathF.Asin(operand0.real);
                    break;
                case "acos":
                    result.real = MathF.Acos(operand0.real);
                    break;
                case "atan":
                    result.real = MathF.Atan(operand0.real);
                    break;
                case "||":
                    result.real = MathF.Sqrt(operand0.real * operand0.real + operand0.imag * operand0.imag);
                    break;
                case "IMAG":
                    result.real = operand0.imag;
                    break;
                case "REAL":
                    result.real = operand0.real;
                    break;
                case "Arg":
                    result.real = MathF.Atan2(operand0.imag, operand0.real);
                    break;
                default:
                    break;
            }
            return result;
        }
        private int LastIndex(string str, string c)
        {
            int result = -1;
            int bracketCount = 0;

            for (int i = 0; i < str.Length + 1 - c.Length; i++)
            {
                if (str[i] == '(')
                {
                    bracketCount++;
                }
                else if (str[i] == ')')
                {
                    bracketCount--;
                }
                else if (str.Substring(i, c.Length) == c && bracketCount == 0)
                {
                    result = i;
                }
            }
            return result;
        }
        #endregion

        #region customStruct
        public struct num
        {
            public float real;
            public float imag;
            public override string ToString()
            {
                return $"real: {real}, imag: {imag}";
            }
            public num(float r = float.NaN, float i = float.NaN)
            {
                real = r;
                imag = i;
            }
            public static num? Null => null;
        }
        public struct conversion
        {
            public string variable;
            public num value;
            public conversion(string v, float r = float.NaN, float i = float.NaN)
            {
                variable = v;
                value = new num { real = r, imag = i };
            }
        }
        public struct parameter
        {
            public string name;
            public float min;
            public float max;
            public parameter(string s, float m, float n)
            {
                name = s;
                min = m;
                max = n;

            }
        };
        #endregion

        public async Task Process()
        {
            int processed = 0;
            await Task.Run(() =>
            {
                variables = new conversion[parameters.Length];
                int total = 1;
                for (int i = 0; i < variables.Length; i++)
                {
                    variables[i] = new conversion(parameters[i].name, parameters[i].min, 0);
                    total *= ((int)((parameters[i].max - parameters[i].min) / freq) + 1);
                }
                while (variables[variables.Length - 1].value.real <= parameters[parameters.Length - 1].max)
                {
                    if (Array.TrueForAll(conditions.ToArray(), c => Check(c)))
                    {
                        num result = eval("a+bi");//change this later???
                        points.Add(new ScatterPoint(Math.Round(result.real, 2), Math.Round(result.imag, 2)));
                    }
                    processed++;
                    this.Invoke((MethodInvoker)delegate
                    {
                        label7.Text = "Processing: " + processed + "/" + total;
                    });
                    variables[0].value.real = MathF.Round(variables[0].value.real + freq, 2);
                    for (int i = 0; i < variables.Length - 1; i++)
                    {
                        if (variables[i].value.real > parameters[i].max)
                        {
                            variables[i + 1].value.real = MathF.Round(variables[i + 1].value.real + freq, 2);
                            variables[i].value.real = parameters[i].min;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            });
        }

    }
}