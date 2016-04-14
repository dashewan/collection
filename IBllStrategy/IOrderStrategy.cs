using System;

namespace IBLLStrategy
{
    /// <summary>
    /// Interface for the Synchronous/Asynchronous order insert implementation.
    /// Developers could inlement this interface, to add a new order insert strategy without re-compiling the whole BLL 
    /// </summary>
    public interface IOrderStrategy  {

        void Insert(Model.OrderInfo order);
    }
}
