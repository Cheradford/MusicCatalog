using System.Collections;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Controls;
using ComboBox = HandyControl.Controls.ComboBox;

namespace Music.View;

public static class ControlExtensions
{
    public static void AddRange(this ComboBox comboBox, IEnumerable items)
    {
        foreach (var item in items)
        {
            comboBox.Items.Add(item);
        }
    }
    
    public static void AddRange(this UIElementCollection collection, IEnumerable<UIElement> items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }
    
    public static void AddRange(this CheckComboBox comboBox, IEnumerable items)
    {
        foreach (var item in items)
        {
            comboBox.Items.Add(item);
        }
    }
}