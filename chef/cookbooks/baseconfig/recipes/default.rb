# Make sure the Apt package lists are up to date, so we're downloading versions that exist.

cookbook_file "apt-sources.list" do
  path "/etc/apt/sources.list"
end

execute 'apt_update' do
  command 'apt-get update'
end

# Base configuration recipe in Chef.
package "wget"
package "ntp"
package "tree"
package "nginx"
package "mysql-server"
package "ack-grep"
package "apt-transport-https"
cookbook_file "ntp.conf" do
  path "/etc/ntp.conf"
end
cookbook_file "example.com" do
  path "/etc/nginx/sites-available/example.com"
end
# execute 'dotnetcore' do
#   command 'sudo curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg'
#   command 'sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg'
#   command 'sudo sh -c \'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list\''
  
# end


# execute 'mysql_restart' do
#   # Share an additional folder to the guest VM. The first argument is
#   command 'sudo mysql -u root -ppassword -e "GRANT ALL PRIVILEGES ON *.* TO \'team16\'@\'localhost\' IDENTIFIED BY \'password\';"'
#   command 'service ntp restart'


#   command 'sudo service mysql restart'
#   command 'sudo apt-get install apt-transport-https'
#   command 'apt-get update'
#   #command 'sudo apt-get install dotnet-sdk-2.1.4'
#   command 'sudo apt-get install -y --allow-unauthenticated dotnet-sdk-2.1.4'

# end



# cookbook_file "1.sh" do
#   path "/home/vagrant/1.sh"
# end
# execute 'restart' do
  
#   command 'sudo ln -s /etc/nginx/sites-available/example.com /etc/nginx/sites-enabled/example.com'
#   command 'service nginx restart'
#   # command 'cd ../home/vagrant/1.sh'
#   # command './1.sh'
  
# end

