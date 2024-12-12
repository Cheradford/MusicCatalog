using System.Windows.Controls;
using HandyControl.Controls;
using Music.Domain;
using Music.Domain.Models;

namespace Music.View;

public static class ObjectExtensions
{
    public static IEnumerable<CheckComboBoxItem> CreateCheckComboBoxItem(this IEnumerable<Artist> artists)
    {
        foreach (var artist in artists)
        {
            var checkBox = new CheckComboBoxItem();
            checkBox.Content = artist;
            //checkBox.Checked += CheckBox_OnClick;
            yield return checkBox;
        }
    }
    public static IEnumerable<Button> CreateButton<T>(this IEnumerable<T> entities, Action<T>? onClick = null)
    {
        foreach (var entity in entities)
        {
            var button = new Button();
            button.Content = entity;
            if(onClick!= null) button.Click += (o, e) => onClick(entity);
            yield return button;
        }
    }
}