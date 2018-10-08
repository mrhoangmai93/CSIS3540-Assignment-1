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
    //public delegate void MyFilterHandler(EventHandler sender);


    public partial class CarListingsForm : Form
    {
        //public event MyFilterHandler filterHandler;

        List<string> selectYearList = new List<string>();
        List<string> selectMakeList = new List<string>();
        List<string> selectColorList = new List<string>();
        List<string> selectDealerList = new List<string>();

        IEnumerable<Car> query = null;
        private List<Car> listCars;
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

        public void ResetCheckBoxes()
        {
            searchPrice.Checked = false;
            searchEngineSize.Checked = false;
            txtMaxEngineSize.Text = null;
            txtMinEngineSize.Text = null;
            txtMaxPrice.Text = null;
            txtMinPrice.Text = null;
        }

        public void Reset(object sender, EventArgs e)
        {
            ResetCheckBoxes();
            query =  LoadListsNDataGrid(listCars);
            
        }


        //get value of selectedItem from listbox and save them to a list for further use
        public List<string> UpdateSelectItem(List<string> tempList, ListBox triggeredLists)
        {
            tempList.Clear();

            for (int i = 0; i < triggeredLists.SelectedItems.Count; i++)
            {
                string temp = triggeredLists.SelectedItems[i].ToString();
                tempList.Add(temp);
            }
            return tempList;
        
        }

        //event handler for four listboxes
        public void FilterTriggered(object sender, EventArgs e)
        {

            ListBox triggeredLists = sender as ListBox;
            string name = triggeredLists.Name;

            switch (name)
            {
                case "listYears":
                    selectYearList = UpdateSelectItem( selectYearList, triggeredLists);
                    
                    break;
                case "listColors":
                    selectColorList= UpdateSelectItem( selectColorList,  triggeredLists);
                    
                    break;
                case "listDealers":
                    selectDealerList = UpdateSelectItem( selectDealerList, triggeredLists);
                   
                    break;
                case "listMakes":
                    selectMakeList = UpdateSelectItem( selectMakeList, triggeredLists);
                   
                    break;

            }

            query = from cars in listCars
                        where (selectYearList.Contains(cars.Year.ToString())) &&
                                (selectColorList.Contains(cars.Color)) &&
                                (selectDealerList.Contains(cars.Dealer)) &&
                                (selectMakeList.Contains(cars.Make))
                        select cars;

            populateLowerTable();


        }



        public void CheckBoxesFilterHandler(object sender, EventArgs e)
        {
            //MessageBox.Show("event start");
            CheckBox checkboxTriggered = sender as CheckBox;
            string name = checkboxTriggered.Name;

            if(name == "searchPrice")
            {
                //MessageBox.Show("search price");
                if (checkboxTriggered.Checked)
                {
                    //MessageBox.Show("price checked");
                    query = query.Where(car => (decimal)car.Price <= decimal.Parse(txtMaxPrice.Text) 
                                && (decimal)car.Price >= decimal.Parse(txtMinPrice.Text)
                                );
                }
                else
                {
                   // MessageBox.Show("price  NOT checked");
                    query = from cars in listCars
                            where (selectYearList.Contains(cars.Year.ToString())) &&
                                    (selectColorList.Contains(cars.Color)) &&
                                    (selectDealerList.Contains(cars.Dealer)) &&
                                    (selectMakeList.Contains(cars.Make))
                            select cars;
                }
            }
            else
            {
                if (checkboxTriggered.Checked)
                {
                    query = query.Where(car => (decimal)car.EngineSize <= decimal.Parse(txtMaxEngineSize.Text)
                                && (decimal)car.EngineSize >= decimal.Parse(txtMinEngineSize.Text)
                                );
                }
                else
                {
                    query = from cars in listCars
                            where (selectYearList.Contains(cars.Year.ToString())) &&
                                    (selectColorList.Contains(cars.Color)) &&
                                    (selectDealerList.Contains(cars.Dealer)) &&
                                    (selectMakeList.Contains(cars.Make))
                            select cars;
                }

            }

            populateLowerTable();

        }



        public void TxtboxFilterHandler(object sender, EventArgs e)
        {
            TextBox textboxTriggered = sender as TextBox;
            string name = textboxTriggered.Name;
            //MessageBox.Show(name);
            if(name == "txtMinPrice" || name == "txtMaxPrice")
            {
               // MessageBox.Show("Price");
                if (searchPrice.Checked)
                {
                    query = query.Where(car => (decimal)car.Price <= decimal.Parse(txtMaxPrice.Text)
                               && (decimal)car.Price >= decimal.Parse(txtMinPrice.Text)
                               );
                }
            }
            else
            {
                if (searchEngineSize.Checked)
                {
                    query = query.Where(car => (decimal)car.EngineSize <= decimal.Parse(txtMaxEngineSize.Text)
                                && (decimal)car.EngineSize >= decimal.Parse(txtMinEngineSize.Text)
                                );
                }
            }
            populateLowerTable();

        }

        public void populateLowerTable()
        {
            SetDataGridView(dataSelectedCars);
            dataSelectedCars.DataSource = CreateDataTable(query);
            CalculateSelectedDataList(query);
        }


        #region Serialize XML doc
        /// <summary>
        /// Get the car listings from an xml file
        /// </summary>
        public List<Car> GetXmlCarListingsSerialize(string fileName)
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
                
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listCars;
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

        


        public IEnumerable<Car> LoadListsNDataGrid(List<Car> listCars)
        {
            
           

            // Setting up and format UI
            SetDataGridView(dataAllCars);
            SetDataGridView(dataSelectedCars);

            listYears.SelectionMode = SelectionMode.MultiExtended;
            listColors.SelectionMode = SelectionMode.MultiExtended;
            listMakes.SelectionMode = SelectionMode.MultiExtended;
            listDealers.SelectionMode = SelectionMode.MultiExtended;

            dataAllCars.DataSource = CreateDataTable(listCars);
            dataAllCars.Columns["Price"].DefaultCellStyle.Format = "c";
            dataSelectedCars.DataSource = CreateDataTable(listCars);
            dataSelectedCars.Columns["Price"].DefaultCellStyle.Format = "c";

            // Query Makes list
            var makesList = listCars.GroupBy(car => car.Make).Select(g => g.First()).Select(c => c.Make.ToString());
            listMakes.DataSource = makesList.ToList();
            // Select all options
            SetSelectedListBox(listMakes);
            // Query Colors list
            var colorsList = listCars.GroupBy(car => car.Color).Select(g => g.First()).OrderBy(car => car.Color).Select(c => c.Color.ToString());
            listColors.DataSource = colorsList.ToList();
            // Select all options
            SetSelectedListBox(listColors);
            // Query Years list
            var yearsList = listCars.GroupBy(car => car.Year).Select(g => g.First()).OrderBy(c => c.Year).Select(c => c.Year.ToString());


            listYears.DataSource = yearsList.ToList();
            // Select all options
            SetSelectedListBox(listYears);
            // Query Dealers list
            var dealersList = listCars.GroupBy(car => car.Dealer).Select(g => g.First()).OrderBy(car => car.Dealer).Select(c => c.Dealer.ToString());
            listDealers.DataSource = dealersList.ToList();
            // Select all options
            SetSelectedListBox(listDealers);


            // Calculate all Cars
            var count = listCars.Count();
            var average = (from car in listCars select car.Price).Average();
            // Append string to labels
            lblCountAll.Text = count.ToString();
            lblAveragePriceAll.Text = Convert.ToDecimal(average).ToString("C");

            selectColorList = colorsList.ToList();
            selectDealerList = dealersList.ToList();
            selectMakeList = makesList.ToList();
            selectYearList = yearsList.ToList();

            IEnumerable<Car> query = from cars in listCars
                                     select cars;
            //Calculate selected Cars
            orgCalculatedResult();
            return query;
        }



        public void InitLoad(string fileName)
        {
            listCars = GetXmlCarListingsSerialize(fileName);
         

            query = LoadListsNDataGrid(listCars);
            ResetCheckBoxes();
            listYears.SelectedIndexChanged += new System.EventHandler(FilterTriggered);
            listColors.SelectedIndexChanged += new System.EventHandler(FilterTriggered);
            listMakes.SelectedIndexChanged += new System.EventHandler(FilterTriggered);
            listDealers.SelectedIndexChanged += new System.EventHandler(FilterTriggered);

            resetButton.Click += new System.EventHandler(Reset);

            searchEngineSize.CheckedChanged += new System.EventHandler(CheckBoxesFilterHandler);
            searchPrice.CheckedChanged += new System.EventHandler(CheckBoxesFilterHandler);

            txtMinPrice.TextChanged += new System.EventHandler(TxtboxFilterHandler);
            txtMaxPrice.TextChanged += new System.EventHandler(TxtboxFilterHandler);

            txtMinEngineSize.TextChanged += new System.EventHandler(TxtboxFilterHandler);
            txtMaxEngineSize.TextChanged += new System.EventHandler(TxtboxFilterHandler);



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

        public void orgCalculatedResult()
        {
            var count = listCars.Count();
            var average = (from car in listCars select car.Price).Average();

            labelCount.Text = count.ToString();
            labelAverage.Text = average.ToString("C2");
        }

        public void CalculateSelectedDataList(IEnumerable<Car> inputSelection)
        {
            var count = inputSelection.Count();
            var average = (from car in inputSelection select car.Price).Average();
            //System.InvalidOperationException: 'Sequence contains no elements'
            //exception to do


            labelCount.Text = count.ToString();
            labelAverage.Text = average.ToString("C2");
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
