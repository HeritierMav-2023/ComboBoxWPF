using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GestionExpanderTrue
{
    public static class ExpanderPreventCollapseBehavior
    {
        // SelectedValue : on bindera SelectedOption ici (OneWay)
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.RegisterAttached(
                "SelectedValue",
                typeof(string),
                typeof(ExpanderPreventCollapseBehavior),
                new PropertyMetadata(null));

        public static void SetSelectedValue(DependencyObject d, string value) =>
            d.SetValue(SelectedValueProperty, value);

        public static string GetSelectedValue(DependencyObject d) =>
            (string)d.GetValue(SelectedValueProperty);

        // BlockValue : la valeur qui empêche la fermeture (ex: "Aucun")
        public static readonly DependencyProperty BlockValueProperty =
            DependencyProperty.RegisterAttached(
                "BlockValue",
                typeof(string),
                typeof(ExpanderPreventCollapseBehavior),
                new PropertyMetadata(null, OnBlockValueChanged));

        public static void SetBlockValue(DependencyObject d, string value) =>
            d.SetValue(BlockValueProperty, value);

        public static string GetBlockValue(DependencyObject d) =>
            (string)d.GetValue(BlockValueProperty);

        private static void OnBlockValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Expander expander)
            {
                // Supprime l'ancien handler pour éviter les doubles
                expander.Collapsed -= Expander_Collapsed;
                if (e.NewValue != null)
                {
                    expander.Collapsed += Expander_Collapsed;
                }
            }
        }

        private static void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            if (sender is Expander expander)
            {
                string selected = GetSelectedValue(expander);
                string block = GetBlockValue(expander);

                // Si la valeur sélectionnée correspond à la valeur "bloquante",
                // on ré-ouvre immédiatement l'expander.
                if (!string.IsNullOrEmpty(block) && selected == block)
                {
                    // On remets IsExpanded à true (dès que possible)
                    expander.Dispatcher.BeginInvoke(new System.Action(() =>
                    {
                        expander.IsExpanded = true;
                    }));
                }
            }
        }
    }
}
