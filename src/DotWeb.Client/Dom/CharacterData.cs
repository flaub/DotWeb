namespace DotWeb.Client.Dom
{
	public interface CharacterData : Node
	{
		string data { get; set; }
		uint length { get; }

		string substringData(uint offset, uint count);
		void appendData(string arg);
		void insertData(uint offset, string arg);
		void deleteData(uint offset, uint count);
		void replaceData(uint offset, uint count, string arg);
	}
}
