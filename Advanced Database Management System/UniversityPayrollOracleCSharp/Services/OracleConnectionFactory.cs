using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;

namespace UniversityPayrollOracleCSharp.Services;

public sealed class OracleConnectionFactory : IOracleConnectionFactory
{
    private readonly OracleOptions _options;

    public OracleConnectionFactory(IOptions<OracleOptions> options)
    {
        _options = options.Value;
        DataSource = BuildDataSource(_options);
        SchemaOwner = CleanIdentifier(_options.SchemaOwner);
    }

    public string DataSource { get; }
    public string SchemaOwner { get; }

    public async Task<OracleConnection> CreateAdminConnectionAsync()
    {
        return await CreateConnectionAsync(_options.AdminUser, _options.AdminPassword);
    }

    public async Task<OracleConnection> CreateConnectionAsync(string username, string password)
    {
        var builder = new OracleConnectionStringBuilder
        {
            UserID = username.Trim(),
            Password = password,
            DataSource = DataSource,
            Pooling = true,
            ValidateConnection = true
        };

        var connection = new OracleConnection(builder.ConnectionString);
        await connection.OpenAsync();
        return connection;
    }

    public string DbObject(string objectName)
    {
        return $"{SchemaOwner}.{CleanIdentifier(objectName)}";
    }

    public string Sequence(string sequenceName)
    {
        return $"{SchemaOwner}.{CleanIdentifier(sequenceName)}";
    }

    private static string BuildDataSource(OracleOptions options)
    {
        var host = string.IsNullOrWhiteSpace(options.Host) ? "127.0.0.1" : options.Host.Trim();
        var port = options.Port <= 0 ? 1521 : options.Port;
        var database = string.IsNullOrWhiteSpace(options.Database) ? "XE" : options.Database.Trim();
        var connectType = (options.ConnectType ?? "SID").Trim().ToUpperInvariant();

        if (connectType == "SERVICE" || connectType == "SERVICE_NAME")
        {
            return $"{host}:{port}/{database}";
        }

        return $"(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port}))(CONNECT_DATA=(SID={database})))";
    }

    private static string CleanIdentifier(string value)
    {
        var cleaned = Regex.Replace(value ?? string.Empty, "[^A-Za-z0-9_]", string.Empty).ToUpperInvariant();
        if (string.IsNullOrWhiteSpace(cleaned))
        {
            throw new InvalidOperationException("Oracle identifier cannot be empty.");
        }
        return cleaned;
    }
}
