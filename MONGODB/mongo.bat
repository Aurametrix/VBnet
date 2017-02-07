:: MongoService
mongod.exe --config 'mongod.cfg' --install

:: MongoSecure
mongo admin --port 27017 --eval "db.createUser({user: \"UserName\",pwd:\"Password\",roles:[{role:\"root\",db:\"admin\"}]})"
