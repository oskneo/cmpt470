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
execute 'dotnetcore' do
  command 'curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg'
  command 'mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg'
  command 'sh -c \'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list\''
  
end
package "apt-transport-https"
execute 'mysql_restart' do
  # Share an additional folder to the guest VM. The first argument is
  command 'sudo mysql -uroot -ppassword -e "GRANT ALL PRIVILEGES ON *.* TO \'team16\'@\'localhost\' IDENTIFIED BY \'password\';"'
  command 'service mysql restart'
  command 'apt-get install apt-transport-https'
  command 'apt-get update'
  command 'apt-get install -y --allow-unauthenticated dotnet-sdk-2.1.4'

end
cookbook_file "ntp.conf" do
  path "/etc/ntp.conf"
end
cookbook_file "example.com" do
  path "/etc/nginx/sites-available/example.com"
end
execute 'restart' dogi
  command 'service ntp restart'
  command 'sudo ln -s /etc/nginx/sites-available/example.com /etc/nginx/sites-enabled/example.com'
  command 'service nginx restart'
end

