# maui-html-sample

//              GET FUNCTION
    //private async Task<List<StatusModelClass>> getLoginData()
    //{
    //    string _baseUrl = ClsConnections.url;
    //    var returnRespone = new List<StatusModelClass>();
    //    try
    //    {
    //        using (var httpClient = new HttpClient())
    //        {
    //            string url = $"{_baseUrl}/local/logindetails";
    //            var apiResponse = await httpClient.GetAsync(url);
    //            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                var response = await apiResponse.Content.ReadAsStringAsync();
    //                returnRespone =
    //                    JsonConvert.DeserializeObject<List<StatusModelClass>>(response.ToString());
    //            }
    //            else
    //            {
    //                await App.Current.MainPage.DisplayAlert("Alert", "network Error | Code : 1", "OK");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        await App.Current.MainPage.DisplayAlert("Alert", ex.Message + " | Code : 1A", "OK");
    //    }
    //    return returnRespone;
    //}