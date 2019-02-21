build_frontend:
	cd frontend && npm run build

build_docker_images: build_frontend
	docker-compose build

