#  *  Assignment Answers *

## 1. What is the difference between getElementById, getElementsByClassName, and querySelector / querySelectorAll?
In JavaScript, there are several methods to select HTML elements from a webpage.
### getElementById() :
This method selects a single element based on its unique id attribute. Since an id must be unique in an HTML document, this method always returns only one element. It is fast and efficient when the id of the element is known.
### getElementsByClassName()
This method selects all elements that have the same class name. It returns a live HTMLCollection (a list-like object) containing all matching elements.
### querySelector()
This method selects the first element that matches a specified CSS selector. It can select elements using id (#id), class (.class), tag name (div, p), or more complex CSS selectors.
### querySelectorAll()
This method selects all elements that match a specified CSS selector. It returns a static NodeList containing all matching elements.

### 2. How do you create and insert a new element into the DOM?
To create and insert a new element into the DOM, follow these steps:
- Step 1: Create the element
Use document.createElement() to create a new HTML element. Example: let p = document.createElement("p");
- Step 2: Add content
Use textContent or innerHTML to add text or HTML content. Example: p.textContent = "Hello, World!";
- Step 3: Insert the element
Use methods like appendChild() or append() to add the element to the webpage. Example: document.body.appendChild(p);
These steps allow you to dynamically add new elements to a webpage using JavaScript.


## 3. What is Event Bubbling? And how does it work?
Event Bubbling is a mechanism in JavaScript where an event starts from the target element and then propagates (moves upward) through its parent elements in the DOM tree.
For example:
- When a button inside a div is clicked, the click event first occurs on the button
- Then it moves to the parent div
- After that, it continues up to the body and document
This upward movement of the event is called event bubbling, and it happens automatically for most events in JavaScript.


## 4. What is Event Delegation in JavaScript? Why is it useful?
Event Delegation is a technique where a single event listener is added to a parent element instead of adding separate listeners to multiple child elements.
It works because of event bubbling. When a child element is clicked, the event bubbles up to the parent, and the parent handles the event.
### Advantages of Event Delegation:
- Reduces the amount of code
- Improves performance by using fewer event listeners
- Works for dynamically added elements
- Makes the code cleaner and easier to manage
Event Delegation is an efficient and practical way to handle events in large applications.


## 5. What is the difference between preventDefault() and stopPropagation() methods?
Both methods are used inside event handlers, but they serve different purposes.
### preventDefault()
This method prevents the browser's default behavior for an event. For example, clicking a link normally redirects to another page, but using preventDefault() stops the redirection.
### stopPropagation()
This method prevents the event from propagating (bubbling) up to parent elements. For example, if both a button and its parent div have click event listeners, calling stopPropagation() on the button prevents the parent's event handler from executing.
