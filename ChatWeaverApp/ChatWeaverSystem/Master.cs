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

        public List<string> enumDataTypes = new List<string>();

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
            this.dataType = "Enum";
            this.defaultValue = defaultValue;
            this.uiControl = "Combo Box";
            this.linkedToPub = false;
            this.enumDataTypes = enumDataType;
        }

        public ParameterData(ParameterData copyParam)
        {
            this.name = copyParam.name;
            this.dataType = copyParam.dataType;
            this.defaultValue = copyParam.defaultValue;
            this.uiControl = copyParam.uiControl;
            this.linkedToPub = copyParam.linkedToPub;
            this.enumDataTypes = new List<string>();
            if(copyParam.dataType == "Enum")
            {
                foreach (string item in copyParam.enumDataTypes)
                {
                    this.enumDataTypes.Add(item);
                }
            }
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
