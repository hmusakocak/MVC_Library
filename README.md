<div><h1 align="center">MVC Library Management</h1></div>

- **Register and login form components are included inside of Content folder.**
- **Login page isn't modified yet. Update will come as soon as possible.**(done!)
- **Templates from w3schools aren't modified. Templates are staying how they look like when they are taken.**
- **"select-option" struct in register form will be filled by HTMLParser that gets all universities.**(done!)
- **Chatting between users process will be added when student panel is done.**
- **SQL database create script will be shared soon.**
- **!!! You need to change <ins>data source</ins> field in "Web.config" file. The field is located in <ins> connectionStrings</ins> tag !!!**
- **Admin role and controller based authentication will be added.**
```csharp
            //HTML Parser that gets all universities by mining data from given URL.
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            hw.OverrideEncoding = Encoding.UTF8;
            string link = "https://www.unibilgi.net/turkiyedeki-universitelerin-listesi/";

            doc = hw.Load(link);

            int ct = 2;
            while (true)
            {
                var xpath = string.Format("//*[@id='post-23027']/div[2]/table[1]/tbody/tr[{0}]/td[2]", ct);
                var xpath2 = string.Format("//*[@id='post-23027']/div[2]/table[2]/tbody/tr[{0}]/td[2]", ct);
                var node = doc.DocumentNode.SelectSingleNode(xpath);
                var node2 = doc.DocumentNode.SelectSingleNode(xpath2);
                if (node != null)
                {
                    listBox1.Items.Add(node.InnerText);
                }
                else { break; }
                ct++;
            }
```
