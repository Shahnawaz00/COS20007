// counter class
class Counter {

    // class constructor with a label parameter
    constructor(label) {
      this.label = label;
      this.ticks = 0;
    }
  
    // increment method
    increment() {
      this.ticks++;
    }
  
    // reset method
    reset() {
      this.ticks = 0;
    }
  }
  
//clock class
class Clock {

    // class constructor
    constructor() {
      this.hrs = new Counter("hrs");
      this.mins = new Counter("mins");
      this.secs = new Counter("secs");
    }
  
    // tick method, increments the clock by 1 second and resets appropriately
    tick() {
      if (this.secs.ticks <= 58) {
        this.secs.increment();
      } else if (this.mins.ticks <= 58) {
        this.mins.increment();
        this.secs.reset();
      } else if (this.hrs.ticks <= 22) {
        this.hrs.increment();
        this.mins.reset();
        this.secs.reset();
      } else {
        this.hrs.reset();
        this.mins.reset();
        this.secs.reset();
      }
    }
  
    // reset method, resets the clock
    reset() {
      this.hrs.reset();
      this.mins.reset();
      this.secs.reset();
    }
  
    // time method, returns the current time
    get time() {
      return `${this.hrs.ticks.toString().padStart(2, '0')}:${this.mins.ticks.toString().padStart(2, '0')}:${this.secs.ticks.toString().padStart(2, '0')}`;
    }
  }

//main class
class Main {
    static main() {
      // Create an instance of the Clock class
      const clock = new Clock();
  
      // log current time
      console.log(clock.time);
  
      // Tick the clock 
      for (let i = 0; i < 100; i++) {
        clock.tick();
        console.log(clock.time);

      }
  
      // log the updated time
      console.log(clock.time);
  
      // Reset the clock
      clock.reset();
  
      // log reset time
      console.log(clock.time);
    }
  }
  
  // Call the main function to start the program
  Main.main();
  