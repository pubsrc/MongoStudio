using MongoDB.Bson;
using MongoStudio.Constants;
using SynapticEffect.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoStudio.Rendering
{
    class TreeTable
    {
        public static Dictionary<Type, string> dataTypeMapping = new Dictionary<Type, string>
        {
            {typeof(BsonArray),"Array" },
            {typeof(BsonBinaryData),"BinaryData" },
            {typeof(BsonBinarySubType),"BinarySubType" },
            {typeof(BsonBoolean),"Boolean" },
            {typeof(BsonConstants),"Constant" },
            {typeof(BsonDateTime),"DateTime" },
            {typeof(BsonDefaults),"Defaults" },
            {typeof(BsonDocument),"Document" },
            {typeof(BsonDocumentWrapper),"DocumentWrappe" },
            {typeof(BsonDouble),"Double" },
            {typeof(BsonElement),"Element" },
            {typeof(BsonException),"Exception" },
            {typeof(BsonExtensionMethods),"ExtensionMethod" },
            {typeof(BsonInt32),"Int32" },
            {typeof(BsonInt64),"Int64" },
            {typeof(BsonInternalException),"InternalException" },
            {typeof(BsonJavaScript),"JavaScript" },
            {typeof(BsonJavaScriptWithScope),"JavaScriptWithScope" },
            {typeof(BsonMaxKey),"MaxKey" },
            {typeof(BsonMinKey),"MinKey" },
            {typeof(BsonNull),"null" },
            {typeof(BsonObjectId),"ObjectId" },
            {typeof(BsonRegularExpression),"RegularExpression" },
            {typeof(BsonSerializationException),"SerializationException" },
            {typeof(BsonString),"String" },
            {typeof(BsonSymbol),"Symbol" },
            {typeof(BsonSymbolTable),"SymbolTable" },
            {typeof(BsonTimestamp),"Timestamp" },
            {typeof(BsonType),"Type" },
            {typeof(BsonTypeMapper),"TypeMapper" },
            {typeof(BsonTypeMapperOptions),"TypeMapperOption" },
            {typeof(BsonUndefined),"Undefined" },
            {typeof(BsonUtils),"Utils" },
            {typeof(BsonValue),"Value" },
        };
        public static List<TreeListNode> GetTree(List<BsonDocument> list)
        {
            List<TreeListNode> nodes = new List<TreeListNode>();
            int counter = 1;
            foreach (var d in list)
            {
                var node = GetTreeNode(d, counter);
                nodes.Add(node);
                var children = GetChildren(d);
                node.Nodes.AddRange(children.ToArray());
                counter++;
            }
            return nodes;
        }
        public static TreeListNode GetSingleNodeTree(BsonDocument document)
        {
            TreeListNode root = new TreeListNode();
            var node = GetTreeNode(document, 1);
            root.Nodes.Add(node);
            var children = GetChildren(document);
            node.Nodes.AddRange(children.ToArray());
            return root;
        }
        static TreeListNode GetTreeNode(BsonDocument document,int nodeNumber)
        {
            TreeListNode node = new TreeListNode();

            if (document.Contains(MongoConstants.MongoIdKey))
            {
                if (document[MongoConstants.MongoIdKey].GetType() == typeof(BsonObjectId))
                {
                    node.Text = $"({nodeNumber})ObjectId(\"{document[MongoConstants.MongoIdKey].ToString()}\")";
                }
                else
                {
                    node.Text = $"({nodeNumber}){document[MongoConstants.MongoIdKey].ToString()}";
                }
            }
            else
            {
                node.Text = $"({nodeNumber})";
            }

            node.SubItems.Add($"{{ { document.ElementCount} {(document.ElementCount == 1 ? UiConstants.Field : UiConstants.Fields)} }}");
            node.SubItems.Add(dataTypeMapping[document.GetType()]);
            return node;
        }
        private static List<TreeListNode> GetChildren(BsonDocument bsonDocument)
        {
            List<TreeListNode> children = new List<TreeListNode>();
            foreach (var element in bsonDocument.Elements)
            {
                var node = GetNode(element);
                children.Add(node);
            }
            return children;
        }
        static TreeListNode  GetNode(BsonElement element)
        {
            TreeListNode node = new TreeListNode();
            if (element.Value.GetType() == typeof(BsonNull))
            {
                node.Text = element.Name;
                node.SubItems.Add(dataTypeMapping[typeof(BsonNull)]);
               // node.SubItems.Add("null");
            }
            else if (element.Value.GetType() == typeof(BsonObjectId))
            {
                node.Text = element.Name;
                node.SubItems.Add($"ObjectId(\"{element.Value.ToString()}\")");
               // node.SubItems.Add("ObjectId");
            }
            else if (element.Value.GetType() == typeof(BsonDocument))
            {
                BsonDocument innerBsonDocument = (BsonDocument)element.Value;
                node.Text = element.Name;
                node.SubItems.Add($"{{ { innerBsonDocument.ElementCount} {(innerBsonDocument.ElementCount == 1 ? UiConstants.Field : UiConstants.Fields)} }}");
                //node.SubItems.Add("Document");
                var nodeChildren = GetChildren(innerBsonDocument);
                node.Nodes.AddRange(nodeChildren.ToArray());
            }
            else if (element.Value.GetType() == typeof(BsonArray))
            {
                BsonArray innerArray = (BsonArray)element.Value;
                node.Text = element.Name;
                node.SubItems.Add($"[ { innerArray.Count} {(innerArray.Count == 1 ? UiConstants.Element : UiConstants.Elements)} ]");
                //node.SubItems.Add("Array");
                var nodeChildren = GetArrayChildren(innerArray);
                node.Nodes.AddRange(nodeChildren.ToArray());
            }
            else
            {
                node.Text = element.Name;
                node.SubItems.Add(element.Value.ToString());
               // node.SubItems.Add(element.Value.GetType().Name);
            }
            node.SubItems.Add(dataTypeMapping[element.Value.GetType()]);
            return node;
        }

        private static List<TreeListNode> GetArrayChildren(BsonArray bsonArray)
        {
            List<TreeListNode> children = new List<TreeListNode>();
            int counter = 0;
            foreach (var item in bsonArray)
            {
                var node = GetNode(item);
                node.Text = $"[ {counter} ]";
                children.Add(node);
                counter++;
            }
            return children;
        }

        private static TreeListNode GetNode(BsonValue element)
        {
            TreeListNode node = new TreeListNode();
            if (element.GetType() == typeof(BsonNull))
            {
                node.SubItems.Add(dataTypeMapping[typeof(BsonNull)]);
                node.SubItems.Add(dataTypeMapping[typeof(BsonNull)]);
            }
            else if (element.GetType() == typeof(BsonObjectId))
            {
                node.SubItems.Add($"ObjectId(\"{element.ToString()}\")");
                node.SubItems.Add("ObjectId");
            }
            else if (element.GetType() == typeof(BsonDocument))
            {
                BsonDocument innerBsonDocument = (BsonDocument)element;
                node.SubItems.Add($"{{ { innerBsonDocument.ElementCount} {(innerBsonDocument.ElementCount == 1 ? UiConstants.Field : UiConstants.Fields)} }}");
                node.SubItems.Add("Document");
                var nodeChildren = GetChildren(innerBsonDocument);
                node.Nodes.AddRange(nodeChildren.ToArray());
            }
            else if (element.GetType() == typeof(BsonArray))
            {
                BsonArray innerArray = (BsonArray)element;
                node.SubItems.Add($"[ { innerArray.Count} {(innerArray.Count == 1 ? UiConstants.Element : UiConstants.Elements)} ]");
                node.SubItems.Add("Array");
                var nodeChildren = GetArrayChildren(innerArray);
                node.Nodes.AddRange(nodeChildren.ToArray());
            }
            else
            {
                node.SubItems.Add(element.ToString());
                node.SubItems.Add(dataTypeMapping[element.GetType()]);
            }
            return node;
        }
    }
}
