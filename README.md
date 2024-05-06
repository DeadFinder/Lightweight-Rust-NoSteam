# Rust-NoSteam
## ⭐ » Donations
| Donate to Kaidoz |
|------------------|
| - https://www.buymeacoffee.com/kaidoz          |
| - https://boosty.to/kaidoz/single-payment/donation/29238            | 
| - https://qiwi.com/n/KAIDOZ            | 
| - VISA: 4279380632007755           | 
| - BTC: 1DNEbR5Yk6a6NXDuQHB2XGAAjaqL8NXvUc | 


| Donate to DeadFinder |
|------------------|
| - A DeadFinder not need donations xd          |


## 📝️ » Information
All information you can find on original page of [NoSteam](https://github.com/Kaidoz/Rust-NoSteam), what i'm changed:
 1. Removed useless code, like a spam in chat
 2. Removed configs (i'm dont like that and also not touched that at all time)
 3. Removed disable of Rust+ on server, now steam players can pair rust+ but pirate players have no chance to do that.
 4. Changed SteamPlatform.BeginPlayerSession and added some accepts of connection like
 ```C#
connection.authStatusSteam, connection.authStatusEAC, connection.authStatusNexus, connection.authStatusCentralizedBans
 ```
 5. Changed to Harmony 3 with 2024 Rust May update.

## 🔧 » Supported operating systems
| System  | Status |
|---------|--------|
| Windows |   ✅   |
| Linux   |   ✅   | 


## 🛠️ » Api and Hooks
#### IsPlayerNoSteam
Check player
```C#
IsSteam(ulong steamid)
IsSteam(Connection connection)
IsSteam(BasePlayer player)
```
##### Example 
```C#
bool IsPlayersSteam(BasePlayer player)
{
    if(Call<bool>("IsSteam", player) == true)
      return true;
    return false;
}
```
### Hooks
#### OnBeginPlayerSession
Returning a non-null value kick player with reason as value.
```C#
object OnBeginPlayerSession(Connection connection, bool isLicense)
{
  string status = isLicense ? "steam" : "nosteam";
  Puts($"{connection.userid} is {status} player c:");
  return null;
}
```
## 🧶 » Credits

[Harmony](https://github.com/pardeike/Harmony) patcher used in the project

[Kaidoz](https://github.com/Kaidoz/Rust-NoSteam) for original of NoSteam
