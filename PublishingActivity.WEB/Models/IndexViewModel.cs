using System.Collections.Generic;

namespace PublishingActivity.WEB.Models
{
    public class IndexViewModel<T>
        where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public T Model { get; set; }
    }
}