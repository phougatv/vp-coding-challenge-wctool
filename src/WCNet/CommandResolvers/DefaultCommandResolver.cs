namespace VP.CodingChallenge.WCNet.CommandResolvers;

internal class DefaultCommandResolver : ICommandResolver
{
	private readonly ICommandFactory _factory;

	public DefaultCommandResolver(ICommandFactory factory)
	{
		_factory = factory;
	}

    public ICommand ResolveCommand(CommandArgument request)
    {
        return _factory.CreateCommand(request);
    }
}
