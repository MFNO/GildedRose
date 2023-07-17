using System.Collections.Generic;
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
            foreach(Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    return;
                }
                item.SellIn--;
                if (item.Quality >= 50) return;

                else if (item.Name == "Aged Brie")
                {
                    if (item.SellIn <= 0) item.Quality += 2;
                    else item.Quality++;
                }

                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn <= 0) item.Quality = 0;
                    else if (item.SellIn <= 5) item.Quality += 3;
                    else if (item.SellIn <= 10) item.Quality += 2;
                    else item.Quality++;
                }
                else if (item.Name.Contains("conjured")) {
                    item.Quality -= 2;
                    if (item.SellIn <= 0)
                    {
                        item.Quality -= 2;
                    }
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
    }
}
