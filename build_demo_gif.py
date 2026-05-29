from PIL import Image, ImageDraw, ImageFont

width, height = 720, 360
bg = (18, 18, 18)
text_color = (245, 245, 245)
frames = []

try:
    font = ImageFont.truetype("C:\\Windows\\Fonts\\Consola.ttf", 18)
except Exception:
    font = ImageFont.load_default()

lines = [
    "Bem vindo ao Brasil Launcher!",
    "Deseja Logar na Microft? [y/n]",
    "Você está logado como bryan",
    "Selecione a versão:",
    "  1.20.2",
    "  1.20.1",
    "-> 1.19.4",
    "Do you want to confirm download? [y/n]",
    "Downloading minecraft: 1.19.4",
    "$Init minecraft {versao}",
    "Processo iniciado",
]

for i in range(len(lines)):
    img = Image.new('RGB', (width, height), color=bg)
    draw = ImageDraw.Draw(img)
    draw.rectangle([(20, 20), (width-20, height-20)], outline=(60, 60, 60), width=2)
    draw.text((34, 32), "$ bash BrasilLauncher-copy/", fill=text_color, font=font)
    y = 72
    for j in range(i+1):
        draw.text((34, y), lines[j], fill=text_color, font=font)
        y += 32
    frames.append(img)

frames[0].save('demo.gif', save_all=True, append_images=frames[1:], duration=800, loop=0)
print('generated', len(frames), 'frames')
