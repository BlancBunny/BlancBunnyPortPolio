# Naver OpenAPI - MovieFinder
#### Naver Developers Open API를 활용한 영화 검색 프로그램 

[MAIN WINDOW](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20NaverMovieFinder/NaverMovieFinder/NaverMovieFinder/MainWindow.xaml)   
[MAIN WINDOW 비하인드 코드](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20NaverMovieFinder/NaverMovieFinder/NaverMovieFinder/MainWindow.xaml.cs)   
[TRAILER WINDOW](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20NaverMovieFinder/NaverMovieFinder/NaverMovieFinder/TrailerWindow.xaml)   
[DB 생성용 SQL](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/WPF%20-%20NaverMovieFinder/NaverMovieFinder/NaverMovieFinder/SQL/OpenApiLab.sql)   

+ UI - mahApps:metro 프레임워크 기반 
+ Naver OpenAPI 검색 기능 활용
+ 즐겨찾기 목록 CRUD용 DB 연결 (MS-SQL, EntityFramework 활용)
+ 영화 트레일러 감상 기능 (유튜브 연동) 

--------------------------------

## 프로그램 실행 화면
#### 검색 기능 
![20210716_1230110697](https://user-images.githubusercontent.com/77951828/125887428-3eafc939-df54-4088-9942-30aa224d55c3.gif)

#### 즐겨찾기 기능
![20210716_1237280007](https://user-images.githubusercontent.com/77951828/125888068-6b8b505b-c616-48c3-bfb9-8fb400bc2d59.gif)

#### 즐겨찾기 목록 - DB 연동 
![image](https://user-images.githubusercontent.com/77951828/125888395-2d5d91ff-5c53-4f98-9ec9-221b37790783.png)

#### 네이버 영화 페이지 
![GOMCAM 20210716_1258320430](https://user-images.githubusercontent.com/77951828/125895844-62a66102-3bc1-4bc4-bd5f-6e1c439b6bb2.gif)

#### 트레일러 보기 - 유튜브 연동 
![image](https://user-images.githubusercontent.com/77951828/125888782-191e4b44-2eaf-4cf5-9898-92ffddcd0241.png)

----------------------------------



## 주요 코드 

#### 즐겨찾기 추가

<pre><code>
List<FavoriteMovies> movies = new List<FavoriteMovies>();
foreach (MovieItem item in grdData.SelectedItems)
{
    FavoriteMovies temp = new FavoriteMovies()
    {
        Title = item.Title,
        Link = item.Link,
        Image = item.Image,
        SubTitle = item.SubTitle,
        PubDate = item.PubDate,
        Director = item.Director,
        Actor = item.Actor,
        UserRating = item.UserRating,
        RegDate = DateTime.Now
    };
    movies.Add(temp);
}

using (var ctx = new OpenApiLabEntities()) // EntityFramework DB open 
{
        ctx.Set<FavoriteMovies>().AddRange(movies);
        ctx.SaveChanges(); // Commit 
        stsResult.Content = $"즐겨찾기 {movies.Count}건 추가 완료.";
        await this.ShowMessageAsync("저장 성공", $"영화 {movies.Count}개를 즐겨찾기에 추가했습니다", 
            MessageDialogStyle.Affirmative, null);
}    
</code></pre>

#### 네이버 API로부터 데이터 요청 

<pre><code>
string openApiUrl = $"https://openapi.naver.com/v1/search/movie?start=1&display=30&query={movieName}";

string resJson = common.GetApiResult(openApiUrl, clientID, clientSecret); // 네이버에 데이터 요청 

var parsedJson = JObject.Parse(resJson); 데이터 키 별로 parsing

int total = Convert.ToInt32(parsedJson["total"]);
int display = Convert.ToInt32(parsedJson["display"]);
var items = parsedJson["items"];
JArray jArray = (JArray)items;

List<MovieItem> movieItems = new List<MovieItem>();

foreach (var item in jArray) // 데이터 항목별로 분류하여 MovieItem 객체에 저장 
{
    MovieItem movie = new MovieItem( 
        common.StripHtmlTag(item["title"].ToString()),
        item["link"].ToString(),
        item["image"].ToString(),
        item["subtitle"].ToString(),
        item["pubDate"].ToString(),
        common.StripPipe(item["director"].ToString()),
        common.StripPipe(item["actor"].ToString()),
        item["userRating"].ToString()
        );
    movieItems.Add(movie); // 저장된 객체를 영화 클래스 리스트에 저장 
}
 grdData.DataContext = movieItems; // 리스트를 데이터그리드에 표시 
</code></pre>

