﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Banna Peal", Description="Causes cart behind to slip.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Red Shell", Description="Auto targets the cart infront.", Value=1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Triple Red Shell", Description="3 Red Shells.", Value=3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Green Shell", Description="Shoots forward Unguided.", Value=6 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Lightning Bolt", Description="Causes others to shrink.", Value=9 },
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}