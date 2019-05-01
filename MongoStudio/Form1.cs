using Core.MongoStudio.Constants;
using Core.MongoStudio.Executors;
using Core.MongoStudio.Queries;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoStudio.Constants;
using MongoStudio.Rendering;
using Newtonsoft.Json.Linq;
using SynapticEffect.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoStudio
{
    public partial class Form1 : Form
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;


        public Form1()
        {
            InitializeComponent();
            int colWidth = (treeListViewOutput.Width - 100) / 2;
            treeListViewOutput.Columns[0].Width = colWidth;
            treeListViewOutput.Columns[1].Width = colWidth;
        }
        private string FormatExecutionTime(double executionTime)
        {
            double secs = executionTime / 1000;
            if (secs >= 60)
            {
                return (secs / 60) + " m";
            }
            return secs + " sec";
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            string rawQuery = txtQueryEditor.SelectedText.Trim();
            if (String.IsNullOrEmpty(rawQuery))
            rawQuery = txtQueryEditor.Text.Trim();
            rawQuery = rawQuery.Replace(Environment.NewLine.ToString(),"");
            txtOutput.Text = String.Empty;
            treeListViewOutput.Nodes.Clear();

            QueryExecutor executor = new QueryExecutor();
            var database = "test";
            var connectionString = "mongodb://localhost:27017";
            MongoUrl url = new MongoUrl(connectionString);
            QueryResult result = executor.Execute(rawQuery, url, database);
            if (result.Success)
            {
                lblExecutionTime.Text = FormatExecutionTime(result.ExecutionTime);
                if(result.Result is IEnumerable<BsonDocument>)
                {
                    RenderListResult(result.Result);
                }
                else if (result.Result is BsonDocument)
                {
                    RenderObjectResult(result.Result);
                }
                else
                {
                    RenderPrimaryResult(result.Result);
                }
            }
            else
            {
                if(result.Result is MongoException)
                {
                    txtOutput.Text = result.Result.Result.ToString();
                    tabOutput.SelectedIndex = 1;
                }
                else if (result.Result is BsonDocument)
                {
                    txtOutput.Text = result.Result.ToString();
                    tabOutput.SelectedIndex = 1;
                }
                else
                {
                    Exception ex = result.Result;
                    txtOutput.Text = ex.Message;
                    tabOutput.SelectedIndex = 1;
                    //txtOutput.Text = result.ErrorMessage;
                }
            }
        }
        void RenderListResult(List<BsonDocument> list)
        {
            tabOutput.SelectedIndex = 0;
            txtOutput.Text = "";
            var root = TreeTable.GetTree(list);
            treeListViewOutput.Nodes.AddRange(root.ToArray());

            if (treeListViewOutput.Nodes.Count > 0)
            {
                treeListViewOutput.ShowLines = true;
                treeListViewOutput.ShowRootLines = false;
                treeListViewOutput.Nodes[0].Expand();

            }

        }
        void RenderObjectResult(BsonDocument bsonDocument)
        {
            tabOutput.SelectedIndex = 0;
            txtOutput.Text = "";
            var root = TreeTable.GetSingleNodeTree(bsonDocument);
            treeListViewOutput.Nodes.Add(root);

            if (treeListViewOutput.Nodes.Count > 0)
            {
                treeListViewOutput.ShowLines = true;
                treeListViewOutput.ShowRootLines = false;
                treeListViewOutput.Nodes[0].Expand();

            }
        }
        void RenderPrimaryResult(dynamic value)
        {
            if (value == null)
            {
                tabOutput.SelectedIndex = 1;
                txtOutput.Text = "null";
            }
            else
            {
                tabOutput.SelectedIndex = 1;
                txtOutput.Text = value.ToString();
            }
        }
    }
}
