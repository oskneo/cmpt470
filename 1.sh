sudo mysql -u root -ppassword -e "GRANT ALL PRIVILEGES ON *.* TO 'team16'@'localhost' IDENTIFIED BY 'password';"





curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list'

sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install -y --allow-unauthenticated dotnet-sdk-2.1.4

sudo ln -s /etc/nginx/sites-available/example.com /etc/nginx/sites-enabled/example.com

sudo service mysql restart
sudo service nginx restart
sudo service ntp restart

cd /home/vagrant/FinalProject
dotnet restore
dotnet ef database update
mysql -u team16 -ppassword -h localhost cmpt470finaldb < /home/vagrant/FinalProject/db_backup.sql
dotnet run