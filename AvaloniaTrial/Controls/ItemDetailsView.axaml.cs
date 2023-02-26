using Avalonia;
using Avalonia.Controls;
using AvaloniaTrial.Models;

namespace AvaloniaTrial.Controls
{
    public partial class ItemDetailsView : UserControl
    {
        public ItemDetailsView()
        {
            InitializeComponent();
        }

        public Item? Item
        {
            get { return _item; }
            set { SetAndRaise(ItemProperty, ref _item, value); }
        }
        private Item? _item;
        public static readonly DirectProperty<ItemDetailsView, Item?> ItemProperty =
            AvaloniaProperty.RegisterDirect<ItemDetailsView, Item?>(nameof(Item), o => o._item, (o, value) => o.Item = value);
    }
}
