from flask import Flask, render_template, request, jsonify
import threading
import socket, select

is_running = True
app = Flask(__name__)
sockets_to_monitor = []
server_socket = None

# @app.route('/')
# def index():
#     return render_template('index.html')

# @app.route('/js/script.js')
# def get_js():
#     return render_template('js/script.js')

# @app.route('/css/style.css')
# def get_css():
#     return render_template('css/style.css')

@app.route('/click')
def click():
    id = request.args.get('id')
    key = request.args.get('key')
    flag = None
    try:
        send_socket((id + ' ' + key).encode())
        # client_socket.send((id + ' ' + key).encode())
        flag = True
    except Exception as e:
        print(e)
        flag = False
    print(f'/click id={id} key={key} socket={flag})')
    return jsonify(success=True)

def send_socket(bytes):
    for socket in sockets_to_monitor:
        if socket == server_socket:
            continue
        try:
            socket.send(bytes)
        except:
            pass

def run_socket():
    global sockets_to_monitor, server_socket
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

    # Set the socket to non-blocking mode
    server_socket.setblocking(False)

    server_address = ('0.0.0.0', 9099)
    server_socket.bind(server_address)
    server_socket.listen(5)

    # List of sockets to be monitored by select
    sockets_to_monitor = [server_socket]

    print("Server is ready to accept connections...")

    while is_running:
        # Use select to get the list of sockets ready for reading
        ready_to_read, _, _ = select.select(sockets_to_monitor, [], [])

        for sock in ready_to_read:
            if sock == server_socket:
                # A new client connection is ready to be accepted
                client_socket, client_address = server_socket.accept()
                print(f"Connected to client {client_address}")
                sockets_to_monitor.append(client_socket)
            else:
                # An existing client sent data or closed the connection
                try:
                    data = sock.recv(1024)
                    if data:
                        print(f"Received data from client {client_address}: {data}")
                        # sock.sendall(data)
                    else:
                        print(f"Connection closed by client {client_address}")
                        sock.close()
                        sockets_to_monitor.remove(sock)
                except:
                    pass
    print('socket_server end')

timer = threading.Timer(0, run_socket)
timer.start()
app.run(host='0.0.0.0', port=9090)
is_running = False
