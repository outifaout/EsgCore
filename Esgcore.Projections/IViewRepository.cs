using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Esgcore.EventStore;

namespace Esgcore.Projections
{
    public interface IViewRepository
    {
        Task<View> LoadViewAsync(string name);

        Task<bool> SaveViewAsync(string name, View view);
    }
}