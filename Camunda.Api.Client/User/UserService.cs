﻿using System.Threading.Tasks;

namespace Camunda.Api.Client.User;

public class UserService
{
  private readonly IUserRestService _api;

  internal UserService(IUserRestService api) => _api = api;

  public QueryResource<UserQuery, UserProfileInfo> Query(UserQuery query = null)
    => new(query, (q, f, m) => _api.GetList(q, f, m), q => _api.GetListCount(q));

  /// <param name="userId">The id of the user to be retrieved.</param>
  public UserResource this[string userId] => new(_api, userId);

  /// <summary>
  /// Create a new user.
  /// </summary>
  /// <param name="profile">The user's profile</param>
  /// <param name="password">The user's password.</param>
  /// <returns></returns>
  public Task Create(UserProfileInfo profile, string password)
    => _api.Create(new CreateUser() { Profile = profile, Credentials = new() { Password = password } });
}