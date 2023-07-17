using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var updaterContext = new ItemUpdater(new CheeseUpdater());
            foreach (Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue; ;
                }
                item.SellIn--;
                if (item.Quality >= 50) continue;

                else if (item.Name == "Aged Brie")
                {
                    updaterContext.UpdateItem(item);
                }

                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    updaterContext.SetUpdater(new BackstageUpdater());
                    updaterContext.UpdateItem(item);
                }
                else if (item.Name.Contains("conjured")) {
                    updaterContext.SetUpdater(new ConjuredUpdater());
                    updaterContext.UpdateItem(item);
                }
                else if (item.SellIn <= 0) {
                    item.Quality -= 2;
                }
                else
                {
                    item.Quality--;
                }
            }
        }

        public interface IItemUpdater
        {
            void UpdateItem(Item item);
        }

        public class CheeseUpdater : IItemUpdater
        {
            public void UpdateItem(Item item)
            {
                if (item.SellIn <= 0) item.Quality += 2;
                else item.Quality++;

            }
        }

        public class BackstageUpdater : IItemUpdater
        {
            public void UpdateItem(Item item)
            {
                if (item.SellIn <= 0) item.Quality = 0;
                else if (item.SellIn <= 5) item.Quality += 3;
                else if (item.SellIn <= 10) item.Quality += 2;
                else item.Quality++;

            }
        }

        public class ConjuredUpdater : IItemUpdater
        {
            public void UpdateItem(Item item)
            {
                item.Quality -= 2;
                if (item.SellIn <= 0)
                {
                    item.Quality -= 2;
                }
            }
        }
        public class ItemUpdater
        {
            private IItemUpdater _updater;
            public ItemUpdater(IItemUpdater updater)
            {
                _updater = updater;
            }

            public void SetUpdater(IItemUpdater updater) => _updater = updater;

            public void UpdateItem(Item item) => _updater.UpdateItem(item);
        }
    }
}
