using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWeaverApp
{
    public class ProjectData
    {
        public List<ParameterData> parameters = new List<ParameterData>();
    }

    public class ParameterData
    {
        public string name;
        public string dataType;
        public string defaultValue;
        public string uiControl;
        public bool linkedToPub;

        public List<string> enumDataTypes;

        public ParameterData(
            string name,
            string dataType,
            string defaultValue,
            string uiControl,
            bool linkedToPub
            )
        {
             this.name = name;
             this.dataType = dataType;
             this.defaultValue = defaultValue;
             this.uiControl = uiControl;
             this.linkedToPub = linkedToPub;
        }

        /// <summary>Instantiate new param data for enum data type </summary>
        public ParameterData(
            string name,
            string defaultValue,
            List<string> enumDataType
            )
        {
            this.name = name;
            this.dataType = "enum";
            this.defaultValue = defaultValue;
            this.uiControl = "Combo Box";
            this.linkedToPub = false;
            this.enumDataTypes = enumDataType;
        }
    }

    public static class Master
    {
        public static ProjectData projectData = new ProjectData();

        public static List<string> GetParamAllNames()
        {
            List<string> names = new List<string>();

            foreach (ParameterData data in projectData.parameters)
            {
                names.Add(data.name);
            }

            return names;
        }
    }
}
