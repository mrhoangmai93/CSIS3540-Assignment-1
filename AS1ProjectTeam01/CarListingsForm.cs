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
        // private int newSortColumn;
        // private ListSortDirection newColumnDirection = ListSortDirection.Ascending;
        public CarListingsForm()
        {
            InitializeComponent();

            // Initilize and setup form
            InitLoad();

            // Bring the form back after loaded XML
            BringToTop();

        }

        public void ResetCheckBoxes()
        {
            searchPrice.Checked = false;
            searchEngineSize.Checked = false;
            txtMaxEngineSize.Text = "";
            txtMinEngineSize.Text = "";
            txtMaxPrice.Text = "";
            txtMinPrice.Text = "";
        }

        private void Reset(object sender, EventArgs e)
        {
            ResetCheckBoxes();
            ResetToDefault();
        }


        //get value of selectedItem from listbox and save them to a list for further use
        public List<string> UpdateSelectItem(ListBox triggeredLists)
        {
            List<string> tempList = new List<String>();
            for (int i = 0; i < triggeredLists.SelectedItems.Count; i++)
            {
                string temp = triggeredLists.SelectedItems[i].ToString();
                tempList.Add(temp);
            }
            return tempList;
        }

        //event handler for four listboxes
        private void FilterTriggered(object sender, EventArgs e)
        {
            ListBox triggeredLists = sender as ListBox;
            string name = triggeredLists.Name;
            switch (name)
            {
                case "listYears":
                    selectYearList = UpdateSelectItem(triggeredLists);
                    break;
                case "listColors":
                    selectColorList= UpdateSelectItem(triggeredLists);
                    break;
                case "listDealers":
                    selectDealerList = UpdateSelectItem(triggeredLists);
                    break;
                case "listMakes":
                    selectMakeList = UpdateSelectItem(triggeredLists);
                    break;
            }
            populateLowerTable();
        }

        private void CheckBoxesFilterHandler(object sender, EventArgs e)
        {
            populateLowerTable();
        }
        private void TxtboxFilterHandler(object sender, EventArgs e)
        {
            populateLowerTable();
        }
        public void populateLowerTable()
        {
            // Query all selected options
            query = listCars.Where(car => (
            selectYearList.Contains(car.Year.ToString())) 
            && (selectColorList.Contains(car.Color)) 
            && (selectDealerList.Contains(car.Dealer)) 
            && (selectMakeList.Contains(car.Make))
            );
            // Query price if checked
            if (searchPrice.Checked) {
                if (TxtBoxValidation(searchPrice, txtMinPrice,txtMaxPrice ))
                {
                    query = query.Where(car =>
                      (decimal)car.Price <= decimal.Parse(txtMaxPrice.Text)
                      && (decimal)car.Price >= decimal.Parse(txtMinPrice.Text)
                  );
                }
                
                  
            }

            // Query Engine size if checked
            if (searchEngineSize.Checked) {
                if (TxtBoxValidation(searchEngineSize, txtMinEngineSize,txtMaxEngineSize))
                {
                    query = query.Where(car => (decimal)car.EngineSize <= decimal.Parse(txtMaxEngineSize.Text)
                      && (decimal)car.EngineSize >= decimal.Parse(txtMinEngineSize.Text)
                  );
                }
              
            }
           
            // Display to DataGridView
            ConvertListToDataGridView(query.ToList(), dataSelectedCars);

            // Update Label
            var count = query.Count();
            // Switch to LAMBDA
            if (query.Count() > 0)
            {
                var average = query.Select(car => car.Price).Average();
                labelAverage.Text = average.ToString("C2");
            }
            else
            {
                labelAverage.Text = 0.ToString("C2");
            }
            labelCount.Text = count.ToString();
        }


        #region Serialize XML doc
        /// <summary>
        /// Get the car listings from an xml file
        /// </summary>
        public List<Car> GetXmlCarListingsSerialize()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = Path.GetFullPath(Application.StartupPath + "\\..\\.."),
                };
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "ArrayOfCar";
                xRoot.IsNullable = true;
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Car>), xRoot);
                StreamReader carsFile = new StreamReader(openFileDialog.FileName);
                listCars = xmlFormat.Deserialize(carsFile) as List<Car>;

                // Sort all cars by Make, Price, Year and Color
                var carsSorted = from car in listCars
                                orderby car.Make, car.Price, car.Year, car.Color
                             select car;
                listCars = carsSorted.ToList();
                carsFile.Close();
                }
                else
                {
                    // Quit the app
                    System.Environment.Exit(1);

                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                // Quit the app
                System.Environment.Exit(1);
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

        


        public void ResetToDefault()
        {
            // Unregistered listbox SelectedIndexChanged event
            listYears.SelectedIndexChanged -= FilterTriggered;
            listColors.SelectedIndexChanged -= FilterTriggered;
            listMakes.SelectedIndexChanged -= FilterTriggered;
            listDealers.SelectedIndexChanged -= FilterTriggered;

            // Select all options AND reassign local variable
            SetSelectedListBox(listMakes);
            selectMakeList = UpdateSelectItem(listMakes);
            // Select all options AND reassign local variable
            SetSelectedListBox(listColors);
            selectColorList = UpdateSelectItem(listColors);
            // Select all options AND reassign local variable
            SetSelectedListBox(listYears);
            selectYearList = UpdateSelectItem(listYears);
            // Select all options AND reassign local variable
            SetSelectedListBox(listDealers);
            selectDealerList = UpdateSelectItem(listDealers);

            // register listbox SelectedIndexChanged event
            listYears.SelectedIndexChanged += FilterTriggered;
            listColors.SelectedIndexChanged += FilterTriggered;
            listMakes.SelectedIndexChanged += FilterTriggered;
            listDealers.SelectedIndexChanged += FilterTriggered;
            populateLowerTable();
        }

      

        //print error message for textbox input
        public bool errorForTxtBox(CheckBox checkbox, string input = "")
        {
            string print;
            if(input == "minmax")
            {
                print = "minimum value should be smaller than maximum value";
            }
            else
            {
                print = "Price is missing or is not a number";
            }
            MessageBox.Show(print);
            checkbox.Checked = false;
            return false;
        }

        //handling textboxes
        public bool TxtBoxValidation(CheckBox checkbox ,TextBox minTxt, TextBox maxTxt)
        {
            
            try
            {
                decimal min = decimal.Parse(minTxt.Text);
                decimal max = decimal.Parse(maxTxt.Text);
                if (min > max)
                {
                    return errorForTxtBox(checkbox, "minmax");
                }
            }
            catch (Exception e)
            {
                return errorForTxtBox(checkbox);
            }
            

            return true;
            
        }



        public DataGridViewTextBoxColumn[] GetListColumns()
        {
            DataGridViewTextBoxColumn[] arrayDgc = new DataGridViewTextBoxColumn[6];
            arrayDgc[0] = GetDataGrid("Make");
            arrayDgc[1] = GetDataGrid("Year");
            arrayDgc[2] = GetDataGrid("Color");
            arrayDgc[3] = GetDataGrid("Engine Size");
            arrayDgc[4] = GetDataGrid("Price");
            arrayDgc[5] = GetDataGrid("Dealer");
            return arrayDgc;
        }
        public void InitLoad()
        {
            listCars = GetXmlCarListingsSerialize();


            // query = LoadListsNDataGrid();
            // ResetCheckBoxes();

            // Setting up and format UI
            SetDataGridView(dataAllCars);
            SetDataGridView(dataSelectedCars);

            listYears.SelectionMode = SelectionMode.MultiExtended;
            listColors.SelectionMode = SelectionMode.MultiExtended;
            listMakes.SelectionMode = SelectionMode.MultiExtended;
            listDealers.SelectionMode = SelectionMode.MultiExtended;

            // Init array of 6 DataGridViewTextBoxColumn and assign column
            // Add column to DataGridView
            dataAllCars.Columns.AddRange(GetListColumns());
            dataSelectedCars.Columns.AddRange(GetListColumns());
            // Format Price column to currency
            dataAllCars.Columns[4].DefaultCellStyle.Format = "c";
            dataSelectedCars.Columns[4].DefaultCellStyle.Format = "c";

            // Display all cars
            ConvertListToDataGridView(listCars, dataAllCars);
            // Display selected cars
            populateLowerTable();

            // Query Makes list
            var makesList = listCars.GroupBy(car => car.Make).Select(g => g.First()).Select(c => c.Make.ToString());
            // Assign data to list box
            listMakes.DataSource = makesList.ToList();
            // Query Colors list
            var colorsList = listCars.GroupBy(car => car.Color).Select(g => g.First()).OrderBy(car => car.Color).Select(c => c.Color.ToString());
            // Assign data to list box
            listColors.DataSource = colorsList.ToList();
            // Query Years list
            var yearsList = listCars.GroupBy(car => car.Year).Select(g => g.First()).OrderBy(c => c.Year).Select(c => c.Year.ToString());
            // Assign data to list box
            listYears.DataSource = yearsList.ToList();
            // Query Dealers list
            var dealersList = listCars.GroupBy(car => car.Dealer).Select(g => g.First()).OrderBy(car => car.Dealer).Select(c => c.Dealer.ToString());
            // Assign data to list box
            listDealers.DataSource = dealersList.ToList();

            // Set default
            ResetToDefault();
            // Calculate all Cars
            var count = listCars.Count();
            var average = listCars.Select(car => car.Price).Average();
            // Append string to labels
            lblCountAll.Text = count.ToString();
            lblAveragePriceAll.Text = Convert.ToDecimal(average).ToString("C");

            // Assign event handler
            resetButton.Click += Reset;
            searchEngineSize.CheckedChanged += CheckBoxesFilterHandler;
            searchPrice.CheckedChanged += CheckBoxesFilterHandler;
            txtMinPrice.TextChanged += TxtboxFilterHandler;
            txtMaxPrice.TextChanged += TxtboxFilterHandler;
            txtMinEngineSize.TextChanged += TxtboxFilterHandler;
            txtMaxEngineSize.TextChanged += TxtboxFilterHandler;

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
        /// <summary>
        /// Init new DataGridViewTextBoxColumn and set headerText
        /// </summary>
        /// <returns>
        /// DataGridViewTextBoxColumn
        /// </returns>
        private DataGridViewTextBoxColumn GetDataGrid(string headerText)
        {
            DataGridViewTextBoxColumn temp = new DataGridViewTextBoxColumn();
            temp.HeaderText = headerText;
            return temp;
        }
        /// <summary>
        /// Update data of DataListView
        /// </summary>
        private void ConvertListToDataGridView(List<Car> list, DataGridView dataGridView)
        {
            // Clear current data
            dataGridView.Rows.Clear();

            // Loop through the list and append to row
            foreach (Car car in list)
            {
                dataGridView.Rows.Add(car.Make, car.Year, car.Color, car.EngineSize, car.Price, car.Dealer);
            }
        }
    }
}
