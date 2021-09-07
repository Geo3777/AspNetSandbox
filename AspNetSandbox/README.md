## How to run in Docker from the commandline

Build in container
```
docker build -t web_george .
```

to run

```
docker run -d -p 8081:80 --name web_container_borys web_george
```

to stop container
```
docker stop web_container_borys
```

to remove container
```
docker rm web_container_borys
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
heroku container:push -a aspnetsandbox1 web
```

Release the container
```
heroku container:release -a aspnetsandbox1 web
```