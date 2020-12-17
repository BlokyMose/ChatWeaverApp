using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWeaverApp.ChatWeaverSystem
{
    public static class System
    {
        public static List<string> DataTypes = new List<string>() { "Integer", "Float", "String", "Enum"};
        public static List<string> UIControls = new List<string>() { "Text Box", "Label"};
        public static List<string> UIControlsEnum = new List<string>() { "Combo Box" };

        public static List<string> DisplayIcons = new List<string>() { "<noIcon>", "🕒","⚡","🚩", "💬","😀","🗣", "✔", "✖", "✩","☕", "📅", "📌", "📢" };

        public enum DataTypesParam { Integer, Float, String, Enum}
    }
}
