namespace CardGameSite.BLL.BusinessModels.Item.Interface 
{
	public interface IElementsListFixed<T> : IElements<T> 
	{
		T This_ { get; set; }
				
	}

}
