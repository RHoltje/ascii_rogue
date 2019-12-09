require "io/console"
require "colorize" 
gold = 7
wall = 1
empty = 0
char = 2
counter = 0
howmany = 0
position_x = 1
position_y = 7
input = ""
high = 15
long = 15

grid = Array.new(high) { Array.new(long) { 0 } } # Array.new(size) { default value }
# grid[1][7] = 2 #character

randomize = Array.new(high) { Array.new(long) { 0 } }
# puts "LOOK BELOW"
# puts grid

  #Randomize walls

for i in 0...high
    for j in 0...long
        grid[i][j] = (rand() * 10).to_i
    end
end

for i in 0...high
    for j in 0...long
        if grid[i][j] == 7
            howmany += 1
        end
    end
end

grid[position_x][position_y] = 2
system "clear"
while input != "q"
    
    #check to see if the user has won before continuing game.
    if counter == howmany
        input = "q"
        puts "\n"
        puts "\n"
        puts "\n"
        puts " \\$$\\   $$  |                        $$ | $\\  $$ |\\__|          $$ |"
        puts "  \\$$\\ $$  /$$$$$$\\  $$\\   $$\\       $$ |$$$\\ $$ |$$\\ $$$$$$$\\  $$ |"
        puts "   \\$$$$  /$$  __$$\\ $$ |  $$ |      $$ $$ $$\\$$ |$$ |$$  __$$\\ $$ |"
        puts "    \\$$  / $$ /  $$ |$$ |  $$ |      $$$$  _$$$$ |$$ |$$ |  $$ |\\__|"
        puts "     $$ |  $$ |  $$ |$$ |  $$ |      $$$  / \\$$$ |$$ |$$ |  $$ | "
        puts "     $$ |  \\$$$$$$  |\\$$$$$$  |      $$  /   \\$$ |$$ |$$ |  $$ |$$\\"
        puts "     \\__|   \\______/  \\______/       \\__/     \\__|\\__|\\__|  \\__|\\__|"
           
                                                                    
       end

       #draw grid and place character on it.
        for i in 0...high
            for j in 0...long
                if grid[i][j] == gold
                print "$ ".green.on_black.blink
                elsif i == position_x && j == position_y
                    print "@ ".colorize(:red)
                elsif grid[i][j] == wall
                    print "||".colorize(:blue)
            
                else
                    print ". ".colorize(:black)
                end
            end
            puts "\n"
        end

        
        

    # ask user to move character
    puts "=========================="
    
    puts "Try to get all the money."
    puts "Move with wasd, or q to quit"
    puts "#{counter} out of #{howmany}"
    puts "==========================="
   
    #get input from user
    input = STDIN.getch

       #clear screen
        system "clear"

       


    #Movement decision tree
    if input == "a"
        if position_y > 0 && grid[position_x][position_y - 1] != wall
            position_y -= 1
        end
    elsif input == "d"
        if position_y < long - 1 && grid[position_x][position_y + 1] != wall
            position_y += 1
        end
    elsif input == "s"
        if position_x < high - 1 && grid[position_x + 1][position_y] != wall
            position_x += 1
        end
    elsif input == "w"
        if position_x > 0 && grid[position_x - 1][position_y] != wall
            position_x -= 1
        end
    end

    #pick up gold and make the spot empty
    if grid[position_x][position_y] == gold
        grid[position_x][position_y] = empty
        counter += 1
    end
  

end

