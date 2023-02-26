using Reactive.Bindings;

namespace AvaloniaTrial.Models
{
    public class Item : BindableBase
    {
        public ReactivePropertySlim<int> No { get; }
        public ReactivePropertySlim<string> Name { get; }

        public Item(int no, string name)
        {
            No = new ReactivePropertySlim<int>(no);
            Name = new ReactivePropertySlim<string>(name);
        }
    }
}
