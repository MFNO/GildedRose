using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void brieIncreasesInQuality()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 5, Quality =1 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 },
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
            Assert.Equal(4, Items[1].Quality);
            Assert.Equal(50, Items[2].Quality);
        }
        [Fact]
        public void sulfurasUnChanging()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                 new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80 , Items[0].Quality);
            Assert.Equal(80, Items[1].Quality);
        }
        [Fact]
        public void ticketsInCrease()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(12, Items[0].Quality);
            Assert.Equal(13, Items[1].Quality);
            Assert.Equal(0, Items[2].Quality);
            Assert.Equal(0, Items[3].Quality);
        }
        [Fact]
        public void standardItem()
        {
            IList<Item> Items = new List<Item> {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20},
                new Item {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20},
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(19, Items[0].Quality);
            Assert.Equal(18, Items[1].Quality);
            Assert.Equal(18, Items[1].Quality);

        }
        [Fact]
        public void conjuredItem()
        {
            IList<Item> Items = new List<Item> {
                new Item {Name = "conjured shit", SellIn = 10, Quality = 20},
                new Item {Name = "conjured ass", SellIn = 5, Quality = 14},
                new Item {Name = "conjured poopoo", SellIn = -1, Quality = 20},
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(18, Items[0].Quality);
            Assert.Equal(12, Items[1].Quality);
            Assert.Equal(16, Items[2].Quality);

        }
    }
}
