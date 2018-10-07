using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AS1ProjectTeam01
{
    public partial class CarListingsForm : Form
    {
        private List<Car> listCars, selectedCars;
        private int newSortColumn;
        private ListSortDirection newColumnDirection = ListSortDirection.Ascending;
        public CarListingsForm()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.GetFullPath(Application.StartupPath + "\\..\\.."),
            };
            InitializeComponent();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Initilize and setup form
                InitLoad(openFileDialog.FileName);
                // Bring the form back after loaded XML
                BringToTop();
            }
            else
            {
                // Quit the app
            }

        }
        #region Serialize XML doc
        /// <summary>
        /// Get the car listings from an xml file
        /// </summary>
        public void GetXmlCarListingsSerialize(string fileName)
        {
            try
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "ArrayOfCar";
                xRoot.IsNullable = true;
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Car>), xRoot);
                StreamReader carsFile = new StreamReader(fileName);
                listCars = xmlFormat.Deserialize(carsFile) as List<Car>;

                // Sort all cars by Make, Price, Year and Color
                var carsSorted = from car in listCars
                                orderby car.Make, car.Price, car.Year, car.Color
                             select car;
                listCars = carsSorted.ToList();
                selectedCars = listCars;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Bring form to top
        public void BringToTop()
        {
            // Show the current form
            this.Show();
            // Keeps the current topmost status of form
            bool top = TopMost;
            // Brings the form to top
            TopMost = true;
            // Set form's topmost status back to whatever it was
            TopMost = top;
        }
        #endregion

        public void InitLoad(string fileName)
        {
            GetXmlCarListingsSerialize(fileName);


            // Setting up and format UI
            SetDataGridView(dataAllCars);
            SetDataGridView(dataSelectedCars);

            listYears.SelectionMode = SelectionMode.MultiExtended;
            listColors.SelectionMode = SelectionMode.MultiExtended;
            listMakes.SelectionMode = SelectionMode.MultiExtended;
            listDealers.SelectionMode = SelectionMode.MultiExtended;
            dataAllCars.DataSource = CreateDataTable(listCars);
            dataAllCars.Columns["Price"].DefaultCellStyle.Format = "c";
            dataSelectedCars.DataSource = CreateDataTable(selectedCars);
            dataSelectedCars.Columns["Price"].DefaultCellStyle.Format = "c";

            // Query Makes list
            var makesList = listCars.GroupBy(car => car.Make).Select(g => g.First()).Select(c => c.Make.ToString());
            listMakes.DataSource = makesList.ToList();
            // Select all options
            SetSelectedListBox(listMakes);
            // Query Colors list
            var colorsList = listCars.GroupBy(car => car.Color).Select(g => g.First()).Select(c => c.Color.ToString());
            listColors.DataSource = colorsList.ToList();
            // Select all options
            SetSelectedListBox(listColors);
            // Query Years list
            var yearsList = listCars.GroupBy(car => car.Year).Select(g => g.First()).Select(c => c.Year.ToString());
            listYears.DataSource = yearsList.ToList();
            // Select all options
            SetSelectedListBox(listYears);
            // Query Dealers list
            var dealersList = listCars.GroupBy(car => car.Dealer).Select(g => g.First()).Select(c => c.Dealer.ToString());
            listDealers.DataSource = dealersList.ToList();
            // Select all options
            SetSelectedListBox(listDealers);

            // Calculate all Cars
            var count = listCars.Count();
            var average = (from car in listCars select car.Price).Average();
            // Append string to labels
            lblCountAll.Text = count.ToString();
            lblAveragePriceAll.Text = Convert.ToDecimal(average).ToString("C");

            //Calculate selected Cars
            CalculateSelectedDataList();
        }
        public void SetDataGridView(DataGridView gridView)
        {
            gridView.Columns.Clear(); // any columns created by the designer, get rid of them
            gridView.ReadOnly = true; // no cell editing allowed
            gridView.AllowUserToAddRows = false; // no rows can be added or deleted
            gridView.AllowUserToDeleteRows = false;
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            gridView.RowHeadersVisible = false;
            gridView.AutoSize = false; // don't autosize the cells
                                       // right justify everything
            gridView.ColumnHeadersDefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight;
            gridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void SetSelectedListBox(ListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetSelected(i, true);
            }
        }
        public void CalculateSelectedDataList()
        {
            var count = selectedCars.Count();
            var average = (from car in selectedCars select car.Price).Average();

            lblCountSelected.Text = count.ToString();
            lblAverageSelected.Text = Convert.ToDecimal(average).ToString("C");
        }

        // Convert list<Car> to Datatable for sorting column header
        // Reference: https://stackoverflow.com/questions/18746064/using-reflection-to-create-a-datatable-from-a-class
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
