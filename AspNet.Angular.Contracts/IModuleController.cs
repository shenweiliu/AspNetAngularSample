
namespace AspNet.Angular.Contracts
{
    public enum DivisionContext
    {
        Unknown = 0,
        Common = 1,
        BzTwo = 2,
        BzThree = 3        
    }

    public interface IModuleController
    {        
        DivisionContext Division { get; }
    }
}
