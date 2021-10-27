# **Unity Projects**

## Prototype1 -- Car
- Unity Editor
- Managing and Importing Assets
- C# Scripts
  - `Start()`
  - `Update()`
- Camera Positioning and Following
- User Keyboard Input
  - `Input.GetAxis()`
- Moving Game Objects Over Time 
  - `transform.position()`
  - `Rotate()`
  - `Vector3.forward`
  - `Time.deltaTime`

## Prototype2 -- Shooter
- Camera Perspective and Isometric
- Local vs. Global variables
- Controlling and Restricting Object Movement
  - `transform.Translate()`
  - `transform.position = new Vector3()`
  - `Input.GetKeyDown(KeyCode.Space)`
- Creating and Destroying Objects
  - `Instantiate()`
  - `Destroy()`
- Creating Prefabs
- Random Generation
  - `Random.Range()`
- Controlling Intervals
  - `InvokeRepeating()`
- Colliders and Triggers
  - `OnTriggerEnter(Collider other)`
- Logging Information
  - `Debug.Log()`

## Prototype3 -- Side-Scroller
- Physics
  - Speed, Mass, Force, and Gravity
  - `GetComponent<Rigidbody>()`
  - `AddForce(Vector3.up)`
  - `ForceMode.Impulse`
  - `Physics.gravity`
- Booleans and Conditional Statements
- Tags
- Collision Detection
  - `OnCollisionEnter(Collision collision)`
  - `gameObject.CompareTag("Object Name")`
- Script Communication
  - `script = GameObject.Find("Object Name with Script").GetComponent<PlayerController>();` 
- Animations
  - States, Layers, and Transitions
  - `GetComponent<Animator>()`
  - `.SetTrigger()`
  - `.SetBool()`
  - `.SetInteger()`
- Particles
  - `.Play()`
  - `.Stop()`
- Audio
  - Adding Audio Sources to Camera 
  - Playing Audio Clips
  - `GetComponent<AudioSource>()`
  - `.PlayOneShot()`

## Prototype4 -- Rolling Balls
- Camera as child object
- Global vs. Local coordinates
- Moving in Direction of Objects
  - `object = GameObject.Find("Object Name")`
  - `AddForce(object.transform.forward)`
- Physics Materials
  -  Bounciness
- Defining Vectors in 3D
- Methods with Return Values 
- Concatenation
- IEnumerators and Coroutines
  - `IEnumerator Method() {yield return new WaitForSeconds()}`
  - `StartCoroutine(Method())`
- Showing and Hiding Objects
  - `gameObject.SetActive()`
- For-Loops
- Incrementing
- Counting Objects
  - `FindObjectsOfType<type>().Length`
  
## Working Game -- "Blast 'em!"
-
