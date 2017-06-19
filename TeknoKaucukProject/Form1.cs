using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TeknoKaucukProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int firstcount = Convert.ToInt32(TextBox1.Text); //birinci textbox değeri alınır
            int secondcount = Convert.ToInt32(TextBox2.Text); //ikinci textbox değeri alınır
            int thirdcount = Convert.ToInt32(TextBox3.Text); //üçüncü textbox değeri alınır
            int result = (firstcount + secondcount)*thirdcount;
            // birinci ve ikinci sayı toplanarak üçüncü sayı ile çarpılır
            textBox4.Text = Convert.ToString(result); //sonuç dördüncü textbox a yazılır

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 200; i++) // 1'den 200'e kadar sayılar yazılır
            {
                if (i%3 == 0 && i%5 == 0) //Sayının hem 3'ün hem de 5'in katı olduğu durum
                {
                    if (i <= 100) //eğer 100'den küçükse sayı yerine ZigZag yazılsın
                    {
                        Sayılar.Items.Add("ZigZag");
                    }
                    else //eğer 100'den büyükse sayı yerine ZagZig yazılsın
                    {
                        Sayılar.Items.Add("ZagZig");
                    }
                }

                else if (i%3 == 0) //Sayı sadece 3'ün katıysa Zig yazılsın
                {
                    Sayılar.Items.Add("Zig");
                }


                else if (i%5 == 0) //Sayı sadece 5'in katıysa Zag yazılsın
                {
                    Sayılar.Items.Add("Zag");
                }
                else
                {
                    Sayılar.Items.Add(i); //3'ün veya 5'in katı olmadığı durumlarda sayının kendisi yazılsın
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(TextBox5.Text);

            if (count >= 16) //Textboxa 1-15 arasında değer giriniz uyarısının verilmesi
            {
                MessageBox.Show("Lütfen 1-15 arasında bir tam sayı giriniz!..");
            }
            else
            {
                {

                    DataTable dataTable = new DataTable();

                    for (int i = 0; i <= count; i++) //Çarpım tablosunun satır ve sütunlarının oluşturulması
                    {
                        if (i == 0)
                        {
                            dataTable.Columns.Add("X");
                        }
                        else
                        {
                            dataTable.Columns.Add(i.ToString());
                            dataTable.Rows.Add(i);
                        }


                    }
                    for (int i = 1; i <= count; i++) //Çarpım işlemlerinin yapılması
                    {
                        for (int j = 1; j <= count; j++)
                        {
                            dataTable.Rows[i - 1][j] = i*j;
                        }
                    }

                    dataGridView1.DataSource = dataTable;
                    for (int i = 0; i <= count; i++)
                    {
                        dataGridView1.Columns[i].Width = 50;
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Metin Dosyası |*.txt";
            file.Title = "Metin Dosyasını Seçiniz..";
            file.ShowDialog(); //Metin dosyasının seçilmesi
            string filePath = file.FileName;
            StreamReader st = File.OpenText(filePath);
            List<double> numbers = new List<double>(); // rakamların tutulacagi double tipinde listenin tanımlanması

            while (!st.EndOfStream) // okunan metin dosyasında satır bazlı gezinmek icin
            {
                IEnumerable<string> array = Regex.Split(st.ReadLine(), @"\s+").Where(s => s != string.Empty);
                // sayılar arasında bir karakterden fazla bosluk olabilir bu durumdan kurtulmak icin string.Empty ile kontrol edilmesi

                foreach (string t in array) // okunan satırdaki rakamları double'a convert islemi
                {
                    try
                        // istenmeyen karakterler gelmiş olabilir bunun icin try- catch blogu(burada kullanıcıya uyari verilebilir)
                    {
                        numbers.Add(Convert.ToDouble((t)));
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

            }
            numbers.Sort(); // rakamların sıralama islemi                

            foreach (double t in numbers) // rakamları ekranda listeleme islemi
            {
                TextBox8.Text += Convert.ToString(t, CultureInfo.InvariantCulture) + " ";
                TextBox8.AppendText(Environment.NewLine);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int number = Convert.ToInt32(textBox6.Text);
            int newFibonacciNumber = 1;
            int oldFibonacciNumber = 0;
            int temp;
            for (int i = 0; i < number - 2; i++)  //Fibonaccı dizisi her sayının kendinden öncekiyle toplanması sonucu oluşan sayı dizisidir
            {
                temp = newFibonacciNumber;      //for döngüsünde sayıyı bulmak için gerekn işlem yapılmıştır
                newFibonacciNumber += oldFibonacciNumber;
                oldFibonacciNumber = temp;

            }
            label1.Text = newFibonacciNumber.ToString(); //bulunan sayı ekrana yazdırılır
        }

      
    }
}
        

      

