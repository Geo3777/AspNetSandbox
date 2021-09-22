#George sandbox project for back-end course
name | value
--- | ---
language | C#
databse | postgres
deployed | https://dashboard.heroku.com/apps/aspnetsandbox2



## How to run in Docker from the commandline

Navigate to [AspNetSandbox](AspNetSandbox) directory

Build in container
```
docker build -t web_george .
```

to run

```
docker run -d -p 8081:80 --name web_container_george web_george
```

to stop container
```
docker stop web_container_george
```

to remove container
```
docker rm web_container_george
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a aspnetsandbox2 web
```

Release the container
```
heroku container:release -a aspnetsandbox2 web
```
